--1.	Write a query to display your birthday( day of week)

declare @bdaydate date = '2004-07-19'
select @bdaydate 'Date of Birth', datename(dw, @bdaydate)  'Day of Week'
 
--2.	Write a query to display your age in days

declare @bdaydate date = '2004-07-19'
select @bdaydate 'Date of Birth', datediff(day, @bdaydate, getdate())  'Age in Days'
 
-- emp and dept tables creation and insertion

create table dept(
deptno int primary key,
dname varchar(30),
loc varchar(30)
)

insert into dept values(10,'ACCOUNTING','NEW YORK'),
(20,'RESEARCH','DALLAS'),
(30,'SALES','CHICAGO' ),
(40,'OPERATIONS','BOSTON')

create table emp(
empno int primary key,
ename varchar(30) not null,
job varchar(30) not null,
mgr_id int,
hire_date varchar(30),
salary int,
comm int,
deptno int references dept(deptno)
)
 
insert into emp values 
(7369, 'SMITH', 'CLERK', 7902, '17-DEC-21', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '20-JUL-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '22-FEB-21', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '02-APR-20', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '28-JUL-20', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '01-MAY-19', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '09-JUN-15', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '19-APR-17', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '17-NOV-24', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '08-SEP-23', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '23-JUL-20', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '03-DEC-11', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '03-JUL-20', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '23-JAN-19', 1300, NULL, 10)

select * from emp

--3.	Write a query to display all employees information those who joined before 5 years in the current month
--(Hint : If required update some HireDates in your EMP table of the assignment)

select * from emp where datediff(year, hire_date, getdate()) = 5 and datename(month,hire_date) = datename(month,getdate())

 
--4.	Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
--	After completing above all actions, recall the deleted row without losing increment of second row.

create table empl(
empno int primary key,
ename varchar(30),
salary int,
doj date
)

begin transaction
--a. First insert 3 rows 
insert into empl values
(1, 'Karthik', 35000, '2021-05-20'),
(2, 'Mario', 30000, '2023-09-05'),
(3, 'Kabali', 32000, '2020-07-19')
select * from empl
save transaction a

--b. Update the second row sal with 15% increment 
update empl set salary = salary * 1.15 where empno = 2
select * from empl
save transaction b

--c. Delete first row.
delete from empl where empno = 1
select * from empl

--	After completing above all actions, recall the deleted row without losing increment of second row.
rollback transaction b
select * from empl
commit

 
--5.    Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
--      a. For Deptno 10 employees 15% of sal as bonus.
--	    b. For Deptno 20 employees  20% of sal as bonus
--	    c. For Others employees 5%of sal as bonus

create or alter function fn_calcbonus(@deptno int, @salary int)
returns int
as begin
	declare @bonus int

    if @deptno = 10
	begin
        set @bonus = @salary * 0.15
    end
	else if @deptno = 20
	begin
        set @bonus = @salary * 0.20
    end
	else
	begin
        set @bonus = @salary * 0.05
	end
    return @bonus
end

select empno 'Employee Id', ename 'Employee Name', deptno 'Department No', Salary, dbo.fn_calcbonus(deptno, salary) 'Bonus' from emp


--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)

create or alter proc sp_salupdate 
as begin 
	update emp set salary = salary + 500 where deptno = 
									(select deptno from dept where dname = 'SALES') and salary < 1500
end

exec sp_salupdate

select * from emp where deptno = (select deptno from dept where dname = 'SALES')

