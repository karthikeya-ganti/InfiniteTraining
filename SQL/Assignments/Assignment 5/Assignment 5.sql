--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition
--   a) HRA as 10% of Salary
--   b) DA as 20% of Salary
--   c) PF as 8% of Salary
--   d) IT as 5% of Salary
--   e) Deductions as sum of PF and IT
--   f) Gross Salary as sum of Salary, HRA, DA
--   g) Net Salary as Gross Salary - Deductions
--Print the payslip neatly with all details

select * from emp

create or alter proc sp_emppayslip @empid int
as begin
		declare @esalary int
		set @esalary = (select salary from emp where empno = @empid)
		
		declare @hra int = 0.1 * @esalary
		declare @da int = 0.2 * @esalary
		declare @pf int = 0.08 * @esalary
		declare @it int = 0.05 * @esalary
		declare @deductions int = @pf + @it
		declare @gross int = @esalary + @hra + @da
		declare @net int = @gross - @deductions

		declare @ename varchar(20), @job varchar(20), @deptno int, @mngrname varchar(20)
		select @ename = e.ename, @job = e.job, @deptno = e.deptno from emp e where e.empno = @empid
		select @mngrname = m.ename from emp m where m.empno = 
				(select mgr_id from emp where empno = @empid)

		print 'Payslip details of the employee: '
		print 'Employee ID: ' + cast(@empid as varchar(4))
		print 'Employee Name: ' + @ename
		print 'Job Designation: ' + @job
		if(@mngrname is not null)
		begin
			print 'Manager Name: ' + @mngrname
		end
		print 'Department No: ' + cast(@deptno as varchar(2))
		print 'Salary = ' + cast(@esalary as varchar(9))
		print 'House Rent Allowance = ' + cast(@hra as varchar(9))
		print 'Dearness Allowance = ' + cast(@da as varchar(9))
		print 'Provident Fund = ' + cast(@pf as varchar(9))
		print 'Income Tax = ' + cast(@it as varchar(9))
		print 'Deductions = ' + cast(@deductions as varchar(9))
		print 'Gross Salary = ' + cast(@gross as varchar(9))
		print 'Net Salary = ' + cast(@net as varchar(9))
end

exec sp_emppayslip 7900


--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc
--Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match and stop manipulation 

create table holiday(
holiday_date date,
holiday_name varchar(30)
)
 
insert into holiday values
('2025-01-01', 'New Year'),
('2025-01-14', 'Pongal'),
('2025-05-01', 'May Day'),
('2025-08-15', 'Independence Day'),
('2025-10-20', 'Diwali'),
('2025-12-25', 'Christmas')

select * from holiday

create or alter trigger trg_restrictdml
on emp
for insert,update,delete
as begin
	declare @holidayname varchar(30)
	select @holidayname = holiday_name from holiday where holiday_date = getdate()
	if(@holidayname is not null)
	begin
		print 'Due To ' + @holidayname + ', you cannot manipulate the data today!'
		rollback
	end
end

begin transaction
update emp set ename = 'KARTHIK' where empno = 7839
rollback
select * from emp