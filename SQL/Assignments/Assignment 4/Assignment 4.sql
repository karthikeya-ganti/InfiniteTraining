use Assignments

--Assignment 4

--1.	Write a T-SQL Program to find the factorial of a given number.
create or alter procedure sp_factorial @num int
as begin
	declare @factorial int, @copynum int
	set @factorial = 1
	set @copynum = @num
	while(@copynum > 1)
	begin 
		set @factorial = @factorial * @copynum
		set @copynum = @copynum - 1
	end
	print 'Factorial of ' + cast(@num as varchar(10)) + ' is: ' + cast(@factorial as varchar(10))
end

exec sp_factorial 6

--2.	Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 
create or alter proc sp_multiplicationTable @num int, @range int
as begin
	declare @index int = 1
	print 'Multiplication Table of ' + cast(@num as varchar(10)) + ' is: '
	while (@index <= @range)
	begin 
		print cast(@num as varchar(10)) + ' * ' + cast(@index as varchar(10)) + ' = ' + cast(@num * @index as varchar(10))
		set @index = @index + 1
	end
end

exec sp_multiplicationTable 10, 10

--Query 3
--student table
--Sid       Sname   
--1         Jack
--2         Rithvik
--3         Jaspreeth
--4         Praveen
--5         Bisa
--6         Suraj

create table student (Sid int primary key, Sname varchar(20))
insert into student values(1, 'Jack'), (2, 'Rithvik'), (3, 'Jaspreeth'), (4, 'Praveen'), (5, 'Bisa'), (6, 'Suraj')

--Marks table
--Mid      Sid     Score
--1        1        23
--2        6        95
--3        4        98
--4        2        17
--5        3        53
--6        5        13

create table marks (Mid int primary key, Sid int foreign key references student(Sid), Score int)
insert into marks values (1, 1, 23), (2, 6, 95), (3, 4, 98), (4, 2, 17), (5, 3, 53), (6, 5, 13)

select * from student
select * from marks

--3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

create or alter function fn_getResult(@smarks int)
returns varchar(4)
as begin
	if(@smarks >= 50)
		return 'Pass'
	return 'Fail'
end

select student.sid 'Id', sname 'Name',score 'Marks', dbo.fn_getResult(score) 'Result' from student, marks where student.sid = marks.sid