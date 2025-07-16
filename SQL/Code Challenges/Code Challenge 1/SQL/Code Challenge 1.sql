create database CodeChallenges

use CodeChallenges

create table books 
(id int primary key, 
title varchar(30),
author varchar(20),
isbn bigint unique, 
published_date datetime) 

insert into books values
(1, 'My First SQL book', 'Mary Parker', 981483029127, '2012-02-22 12:08:17'),
(2, 'My Second SQL book', 'John Mayer', 857300923713, '1972-07-03 09:22:45'),
(3, 'My Third SQL book', 'Cary Flint', 523120967812, '2015-10-18 14:05:44')

select * from books

create table reviews
(id int primary key,
book_id int references books(id),
reviewer_name varchar(20),
content varchar(30),
rating int,
published_date datetime)

insert into reviews values
(1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11'),
(2, 2, 'John Smith', 'My second review', 5, '2017-10-13 15:05:12'),
(3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10')

select * from reviews

create table customers
(id int primary key,
name varchar(20),
age int,
address varchar(30),
salary float)

insert into customers values
(1, 'Ramesh', 32, 'Ahemdabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', 4500.00),
(7, 'Muffy', 24, 'Indore', 10000.00)

select * from customers

create table orders
(oid int primary key, 
date datetime,
customer_id int references customers(id),
amount int)

insert into orders values
(102, '2009-10-08 00:00:00', 3, 3000),
(100, '2009-10-08 00:00:00', 3, 1500),
(101, '2009-11-20 00:00:00', 2, 1560),
(103, '2008-05-20 00:00:00', 4, 2060)

select * from orders

create table employee
(id int primary key,
name varchar(20),
age int,
address varchar(30),
salary float null)

insert into employee values
(1, 'Ramesh', 32, 'Ahemdabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00)

insert into employee (id,name,age,address) values
(6, 'Komal', 22, 'MP'),
(7, 'Muffy', 24, 'Indore')

select * from employee

create table studentdetails
(RegisterNo int primary key,
name varchar(20),
Age int,
Qualification varchar(10),
MobileNo bigint,
Mail_id varchar(30),
Location varchar(20),
Gender varchar(1))

insert into studentdetails values
(2, 'Sai', 22, 'B.E', 9952836777, 'Sai@gmail.com', 'Chennai', 'M'),
(3, 'Kumar', 20, 'BSC', 7890125648, 'Kumar@gmail.com', 'Madurai', 'M'),
(4, 'Selvi', 23, 'B.Tech', 8904567342, 'selvi@gmail.com', 'Selam', 'F'),
(5, 'Nisha', 25, 'M.E', 7834672310, 'Nisha@gmail.com', 'Teni', 'F'),
(6, 'SaiSaran', 21, 'B.A', 7890345678, 'saran@gmail.com', 'Madura', 'F'),
(7, 'Tom', 23, 'BCA', 8901234675, 'Tom@gmail.com', 'Pune', 'M')

select * from studentdetails

--query 1
--write a query to fetch the details of the books written by author whose name ends with er
select * from books where author like '%er'

--query 2
--Display the Title ,Author and ReviewerName for all the books from the above table
select b.title 'Title', b.author 'Author Name', r.reviewer_name 'Reviewer Name'
from books b, reviews r
where b.id = r.book_id

--query 3
--display reviewer name who reviewed more than one book
select reviewer_name 'Reviewer Name' from reviews
group by reviewer_name
having count(*)>1

--query 4
--Display the Name for the customer from above customer table who live in same address 
--which has character o anywhere in address
select name 'Customer Name' from customers 
where address like '%o%'

--query 5
--Write a query to display the Date,Total no of customer placed order on same Date
select o.date 'Date', count(c.id) 'No of Customers'
from orders o, customers c
where o.customer_id = c.id
group by o.date

--query 6
--Display the Names of the Employee in lower case, whose salary is null
select lower(name) 'Names' from employee where salary is null

--query 7
--Write a sql server query to display the Gender,
--Total no of male and female from the above relation
select Gender, count(*) 'Total Male and Female'
from studentdetails
group by gender