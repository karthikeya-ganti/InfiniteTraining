use Assignments

-- Assignment 3

--1. Retrieve a list of MANAGERS. 
select * from emp where empno in (select mgr_id from emp)

--2. Find out the names and salaries of all employees earning more than 1000 per 
--month. 
select ename 'Name', Salary from emp where salary > 1000

--3. Display the names and salaries of all employees except JAMES. 
select ename 'Name', Salary from emp where ename <> 'James'

--4. Find out the details of employees whose names begin with ‘S’. 
select * from emp where ename like 'S%'

--5. Find out the names of all employees that have ‘A’ anywhere in their name. 
select ename 'Name' from emp where ename like '%A%'

--6. Find out the names of all employees that have ‘L’ as their third character in 
--their name. 
select ename 'Name' from emp where ename like '__L%'

--7. Compute daily salary of JONES. 
select ename 'Name', salary/30 'Daily Salary' from emp where ename = 'JONES'

--8. Calculate the total monthly salary of all employees. 
select sum(salary) 'Total Monthly Salary' from emp

--9. Print the average annual salary . 
select avg(salary)*12 'Average Annual Salary' from emp

--10. Select the name, job, salary, department number of all employees except 
--SALESMAN from department number 30. 
select ename 'Name', Job, deptno 'Department No' from emp 
where ename not in (select ename from emp where deptno = 30 and job = 'salesman')

--11. List unique departments of the EMP table. 
select distinct(deptno) 'Unique Departments' from emp

--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. 
--Label the columns Employee and Monthly Salary respectively.
select ename 'Employee', salary 'Monthly Salary' from emp where salary > 1500 and deptno in (10, 30)

--13. Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000. 
select ename 'Name', Job, Salary from emp where job in ('Manager', 'Analyst') and salary not in (100, 3000, 5000)

--14. Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%. 
select ename 'Name', Salary, comm 'Commission' from emp where comm > (salary *1.1)

--15. Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782. 
select ename 'Name' from emp where ename like '%L%L%' and (deptno = 30 or mgr_id =7782)

--16. Display the names of employees with experience of over 30 years and under 40 yrs.
-- Count the total number of employees. 
select ename 'Name' from emp where datediff(year,hire_date,GETDATE()) between 31 and 39
select count(*) 'Total Such Employees' from emp where datediff(year,hire_date,GETDATE()) between 31 and 39

--17. Retrieve the names of departments in ascending order and their employees in descending order. 
select dname 'Department Name', ename 'Employee Name' from dept join emp
on dept.deptno = emp.deptno 
order by dname, ename desc

--18. Find out experience of MILLER. 
select ename 'Employee Name', datediff(year, hire_date, getdate()) 'Experience' from emp where ename = 'Miller'