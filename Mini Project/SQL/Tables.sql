create database MiniProject
use MiniProject

create table users(
userid int primary key identity(1,1),
username varchar(20) not null unique,
password varchar(12) not null,
role varchar(8) check (role in('admin', 'customer')));

create table trains(
train_no int primary key,
train_name varchar(30),
[from] varchar(30),
[to] varchar(30));

create table class(
class_id int primary key,
class_name varchar(10) not null unique);

create table train_class(
train_no int foreign key references trains(train_no),
class_id int foreign key references class(class_id),
seats_available int,
price decimal(10,2),
status varchar(9) check (status in('active','inactive')) default 'active',
primary key (train_no, class_id));

create table customers(
customer_id int primary key identity(1,1),
user_id int foreign key references users(userid),
customer_name varchar(20),
phone varchar(15),
email varchar(20),
gender varchar(6),
age int);

create table bookings (
bid int primary key identity(1,1),
cust_id int foreign key references customers(customer_id),
train_no int foreign key references trains(train_no),
class_id int foreign key references class(class_id),
travel_date date,
booking_date date default getdate(),
seats_booked int check (seats_booked <= 6),
total_cost decimal(10,2),
is_cancelled bit default 0);

create table cancellations (
cancel_id int primary key identity(1,1),
bid int foreign key references bookings(bid),
cancel_date date default getdate(),
seats_cancelled int,
refund_amount decimal(10,2));

select * from cancellations
select * from bookings
select * from customers
select * from trains
select * from class
select * from train_class
select * from users


alter table bookings add status varchar(9) check(status in('active','inactive')) default 'active'
update bookings set status = 'active'