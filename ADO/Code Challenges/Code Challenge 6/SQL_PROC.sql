--Question 1
create table Employee_Details 
(Empid int identity primary key, 
Name varchar(20), 
Salary int, 
Gender varchar(6), 
NetSalary int)
select * from Employee_Details

create or alter proc sp_InsertRecords 
@name varchar(20), @sal int, @gender varchar(6)
as begin
	declare @netsal int = @sal * 0.9
	insert into Employee_Details (name, salary, gender, NetSalary) values (@name, @sal, @gender, @netsal)
	select top 1 * from Employee_Details 
	where name = @name and salary = @sal and gender = @gender and NetSalary = @netsal
	order by Empid desc
end

exec sp_InsertRecords 'Karthik', 1000, 'male'

--Question 2
select * from employee

create or alter proc sp_UpdateSalary @eid int
as begin
	update employee set salary = salary + 100 where id = @eid
end

exec sp_UpdateSalary 1