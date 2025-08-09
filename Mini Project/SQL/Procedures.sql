--Insertions
insert into users (username, password, role) values
('mario', 'mario@123','admin'),
('karthik', 'karthik@123', 'customer')

declare @userid int = (select userid from users where username = 'karthik')
insert into customers (user_id, customer_name, phone, email, gender, age) values
(@userid, 'Karthikeya', '7013695009', 'karthik@gmail.com', 'male', 21)

insert into class values
(1, 'First AC'),
(2, 'Second AC'),
(3, 'Sleeper'),
(4, 'General');

insert into trains values
(12064, 'Chennai Express', 'Vizag', 'Chennai'),
(14728, 'Bangalore Express', 'Vizag', 'Bangalore'),
(17857, 'Noida Express', 'Vizag', 'Noida');

insert into train_class (train_no, class_id, seats_available, price) values
(12064, 1, 50, 650.0),
(14728, 3, 70, 400.0),
(17857, 4, 100, 250.0),
(12064, 2, 40, 550.0);


create or alter proc sp_RegisterUser
	@username varchar(20),
	@password varchar(12),
	@role varchar(8)
as begin
	if exists (select 1 from users where username = @username)
	begin
		raiserror('Username already exists!',16,1)
		return
	end
	insert into users (username, password, role) 
	values (@username, @password, @role)
end

exec sp_RegisterUser 'star', 'star@123', 'admin'


create or alter proc sp_AuthenticateUser
    @username varchar(20),
    @password varchar(12),
    @role varchar(8),
	@authentication bit output
as begin 
    if exists (select 1 from users where username = @username and password = @password and role = @role)
    begin
		set @authentication = 1
    end
	else
	begin
		set @authentication = 0
	end
end

exec sp_AuthenticateUser 'admin', 'admin@123', 'admin'


create or alter proc sp_AddCustomer
	@username varchar(20),
	@name varchar(20),
	@phone varchar(15),
	@email varchar(20),
	@gender varchar(6),
	@age int
as begin
	declare @userid int = (select userid from users where username = @username)
	if @userid is null 
	begin
		raiserror('Username not found.',16,1)
		return
	end

	if exists (select 1 from customers where customer_name = @name)
	begin
		raiserror('Customer already exists.', 16, 1)
		return
	end

	insert into customers (user_id, customer_name, phone, email, gender, age) values
	(@userid, @name, @phone, @email, @gender, @age)
end

exec sp_AddCustomer 'karthik', 'Kabali', '1829830', 'kabali@gmail.com', 'male', 26


create or alter proc sp_ViewTrains
as begin
	select trains.train_no, trains.train_name, [from], [to], class.class_name, seats_available, price, status 
	from trains 
	join train_class 
	on train_class.train_no = trains.train_no 
	join class
	on train_class.class_id = class.class_id
end

exec sp_CustViewTrains


create or alter proc sp_CustViewTrains
as begin
	select trains.train_no, trains.train_name, [from], [to], class.class_name, seats_available, price
	from trains 
	join train_class 
	on train_class.train_no = trains.train_no 
	join class
	on train_class.class_id = class.class_id
	where train_class.status = 'active'
end


create or alter proc sp_CheckSeatsAvailable
    @train_no int,
    @class_id int
as begin
	if not exists (select 1 from train_class where train_no = @train_no and class_id = @class_id)
	begin
		raiserror('Train or Class does not Exists!',16,1)
		return
	end
    select seats_available from train_class where train_no = @train_no and class_id = @class_id
end

exec sp_CheckSeatsAvailable 12064, 1


create or alter proc sp_BookTickets
    @customer_name varchar(20),
    @train_no int,
    @class_id int,
	@travel_date date,
    @seats_booked int
as begin
	if @seats_booked > 6
	begin
		raiserror('Cannot Book More than 6 tickets per transaction.',16,1)
	if not exists (select 1 from customers where customer_name = @customer_name)
	begin
		raiserror('Customer does not exists!',16,1)
		return
	end
	if not exists (select 1 from train_class where train_no = @train_no and status = 'active')
	begin
		raiserror('Cannot book tickets for an inactive train.', 16, 1);
		return;
	end

    declare @seats int
    select @seats = seats_available from train_class
    where train_no = @train_no and class_id = @class_id
 
	if @seats_booked = 0
    begin
        raiserror('Cannot book zero tickets.', 16, 1);
        return;
    end

    if @seats is null
    begin
        raiserror('Invalid train or class selection.', 16, 1);
        return;
    end

    if @seats < @seats_booked
    begin
        raiserror('Not enough seats available.', 16, 1);
        return;
    end
	
	declare @price decimal, @total_cost decimal
	select @price = price from train_class where train_no = @train_no and class_id = @class_id
    set @total_cost = @price * @seats_booked

	declare @cust_id int
	select @cust_id = customer_id from customers where customer_name = @customer_name

    update train_class
    set seats_available = seats_available - @seats_booked
    where train_no = @train_no and class_id = @class_id;
 
    insert into bookings (cust_id, train_no, class_id,travel_date, seats_booked, total_cost)
    values (@cust_id, @train_no, @class_id, @travel_date, @seats_booked, @total_cost);
 
    select 'Ticket booked successfully. Total Cost is ' + cast(@total_cost as varchar) as message, bid as 'bookid' from bookings where bid = (select max(bid) from bookings)
end;

exec sp_BookTickets 'karthikeya', 12064, 1, '2025-08-14', 5


create or alter proc sp_CancelTickets
	@customer_name varchar(20),
	@bookid int,
	@seats_cancelled int
as begin
	if not exists (select 1 from customers where customer_name = @customer_name)
	begin
		raiserror('Customer does not exists!',16,1)
		return
	end
	if not exists (select 1 from bookings where bid = @bookid)
	begin
		raiserror('Customer does not exists!',16,1)
		return
	end
	declare @seats int
	declare @custid int
	select @custid = customer_id from customers where customer_name = @customer_name order by customer_id desc 
    select @seats = seats_booked from bookings
    where cust_id = @custid and bid = @bookid

	if (select is_cancelled from bookings where bid = @bookid) = 1
	begin
		raiserror('Seats already cancelled. Cannot proceed further.', 16, 1);
		return;
	end

	if @seats_cancelled = 0
    begin
        raiserror('Cannot cancel zero tickets.', 16, 1);
        return;
    end

	if @seats is null
    begin
        raiserror('Invalid train or class selection.', 16, 1);
        return;
    end

	if @seats < @seats_cancelled
	begin
        raiserror('Cannot cancel more than booked tickets.', 16, 1);
        return;
    end

	declare @train_no int, @class_id int
	select @train_no = b.train_no, @class_id = b.class_id from bookings b
	where b.bid = @bookid

	declare @price decimal, @refund_amount decimal
	select @price = price from train_class where train_no = @train_no and class_id = @class_id
    set @refund_amount = @price * @seats_cancelled * 0.5

	update train_class
    set seats_available = seats_available + @seats_cancelled
    where train_no = @train_no and class_id = @class_id;

	update bookings
    set seats_booked = seats_booked - @seats_cancelled
    where bid = @bookid
	
	update bookings
	set total_cost = total_cost - @refund_amount
	where bid = @bookid;

	if (select seats_booked from bookings where bid = @bookid) = 0
	begin
		update bookings set is_cancelled = 1 where bid = @bookid
	end

	insert into cancellations (bid, seats_cancelled, refund_amount) values
	(@bookid, @seats_cancelled, @refund_amount)

	select 'Tickets Cancelled Successfully. Refunded Amount = ' + cast(@refund_amount as varchar) as message
end

exec sp_CancelTickets 'kabali',1,11


create or alter proc sp_ViewAllCancellations
as begin
    select ca.cancel_id, b.bid, c.customer_name, t.train_no, t.train_name, cl.class_name, b.booking_date, ca.cancel_date, ca.refund_amount
    from cancellations ca
	join bookings b on ca.bid = b.bid
    join customers c on b.cust_id = c.customer_id
    join trains t on b.train_no = t.train_no
    join class cl on b.class_id = cl.class_id
    order by ca.cancel_date desc;
end

sp_ViewAllCancellations


create or alter proc sp_ViewAllBookings
as begin
    select b.bid, u.username, c.customer_name, t.train_no, t.train_name, t.[from], t.[to], cl.class_name, b.travel_date, b.booking_date, b.seats_booked, b.total_cost, 
        case 
            when b.is_cancelled = 1 then 'Cancelled'
            else 'Confirmed'
        end as BookingStatus
    from bookings b
    join customers c on b.cust_id = c.customer_id
    join users u on c.user_id = u.userid
    join trains t on b.train_no = t.train_no
    join class cl on b.class_id = cl.class_id
    order by b.booking_date desc;
end

exec sp_ViewAllBookings
 

create or alter proc sp_AddTrain
	@train_no int,
	@train_name varchar(30),
	@from varchar(20),
	@to varchar(20),
	@class_id int,
	@seats_available int,
	@price decimal(10,2)
as begin
	if exists (select 1 from train_class where train_no = @train_no and class_id = @class_id)
	begin
		raiserror('Train already exists!',16,1)
		return
	end

	if not exists (select 1 from class where class_id = @class_id)
	begin
		raiserror('Class does not exists!',16,1)
		return
	end

	insert into trains (train_no, train_name, [from], [to])
	values(@train_no, @train_name, @from, @to)

	insert into train_class (train_no, class_id, seats_available, price)
    values (@train_no, @class_id, @seats_available, @price)

	select 'Train Added Successfully.' as message
end

exec sp_AddTrain 70136, 'Train Express', 'Pakistan', 'India', 4, 10, 300.5



create or alter procedure sp_ModifyTrain
    @train_no int,
    @input int,  -- 1 = train name, 2 = from, 3 = to, 4 = class id, 5 = seats, 6 = price, 7 = status
    @class_id int = null,
    @new_value varchar(30) = null,
    @new_int_value int = null,
    @new_decimal_value decimal(10,2) = null
as begin
    if not exists (select 1 from trains where train_no = @train_no)
    begin
        raiserror('Train does not Exists!', 16, 1)
        return
    end

    if @input = 1
    begin
        update trains set train_name = @new_value where train_no = @train_no
        select 'Train Name Updated Successfully.' as message
    end
    else if @input = 2
    begin
        update trains set [from] = @new_value where train_no = @train_no
        select 'From Station Updated Successfully.' as message
    end
    else if @input = 3
    begin
        update trains set [to] = @new_value where train_no = @train_no
        select 'To Station Updated Successfully.' as message
    end
    else if @input = 4
    begin
        if not exists (select 1 from train_class where train_no = @train_no and class_id = @class_id)
        begin
            raiserror('Train-Class Combination Does Not Exists!', 16, 1)
            return
        end
        update train_class set class_id = @new_int_value where train_no = @train_no and class_id = @class_id
        select 'Class has been Updated Successfully.' as message
    end
    else if @input = 5
    begin
        if not exists (select 1 from train_class where train_no = @train_no and class_id = @class_id)
        begin
            raiserror('Train-Class Combination Does Not Exists!', 16, 1)
            return
        end
        update train_class set seats_available = @new_int_value where train_no = @train_no and class_id = @class_id
        select 'Seats Available Updated Successfully.' as message
    end
    else if @input = 6
    begin
        if not exists (select 1 from train_class where train_no = @train_no and class_id = @class_id)
        begin
            raiserror('Train-Class Combination Does Not Exists!', 16, 1)
            return
        end
        update train_class set price = @new_decimal_value where train_no = @train_no and class_id = @class_id
        select 'Price Updated Successfully.' as message
    end
	else if @input = 7
	begin
		if not exists (select 1 from train_class where train_no = @train_no and status = 'inactive')
        begin
            raiserror('Train is already active or does not exist.', 16, 1)
            return
        end
        update train_class set status = 'active' where train_no = @train_no
        select 'Train marked as active successfully.' as message
    end
    else
    begin
        raiserror('Invalid Input!', 16, 1)
    end
end



create or alter proc sp_DeleteTrain
    @train_no int
as begin
    if not exists (select 1 from train_class where train_no = @train_no and status = 'active')
    begin
        raiserror('Train not found or already inactive.', 16, 1);
        return;
    end
 
    update train_class set status = 'inactive' where train_no = @train_no;
 
    select 'Train marked as inactive successfully.' as message
end

exec sp_DeleteTrain 18464


create or alter proc sp_CurrentBooking
	@bid int
as begin
	select b.bid, c.customer_name, t.train_no, t.train_name, t.[from], t.[to], cl.class_name, b.travel_date, b.booking_date, b.seats_booked, b.total_cost
    from bookings b
    join customers c on b.cust_id = c.customer_id
    join users u on c.user_id = u.userid
    join trains t on b.train_no = t.train_no
    join class cl on b.class_id = cl.class_id
	where bid = @bid
end

sp_CurrentBooking 1 

create or alter proc sp_ViewCustomerBookings
	@customer_name varchar(20)
as begin
	if not exists (select 1 from customers where customer_name = @customer_name)
	begin
		raiserror('Customer does not exists!',16,1)
		return
	end
	select b.bid, u.username, c.customer_name, t.train_no, t.train_name, t.[from], t.[to], cl.class_name, b.travel_date, b.booking_date, b.seats_booked, b.total_cost, 
        case 
            when b.is_cancelled = 1 then 'Cancelled'
            else 'Confirmed'
        end as BookingStatus
    from bookings b
    join customers c on b.cust_id = c.customer_id
    join users u on c.user_id = u.userid
    join trains t on b.train_no = t.train_no
    join class cl on b.class_id = cl.class_id
	where c.customer_name = @customer_name
    order by b.booking_date desc;
end

sp_ViewCustomerBookings 'karthikeya'