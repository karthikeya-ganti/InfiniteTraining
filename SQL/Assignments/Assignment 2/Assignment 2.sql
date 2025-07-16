create database Assignments

use Assignments

drop table dept

create table dept(
deptno int primary key,
dname varchar(30),
loc varchar(30)
)

insert into dept values(10,'ACCOUNTING','NEW YORK'),
(20,'RESEARCH','DALLAS'),
(30,'SALES','CHICAGO' ),
(40,'OPERATIONS','BOSTON')

drop table emp

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
(7369, 'SMITH', 'CLERK', 7902, '17-DEC-80', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '20-FEB-81', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '22-FEB-81', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '02-APR-81', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '28-SEP-81', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '01-MAY-81', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '09-JUN-81', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '19-APR-87', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '17-NOV-81', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '08-SEP-81', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '23-MAY-87', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '03-DEC-81', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '03-DEC-81', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '23-JAN-82', 1300, NULL, 10)

--1. List all employees whose name begins with 'A'. 
select * from emp where ename like 'A%'

--2. Select all those employees who don't have a manager. 
select * from emp where mgr_id is null

--3. List employee name, number and salary for those employees who earn in the range 1200 to 1400. 
select ename 'Employee Name', salary 'Salary' from emp
where salary between 1200 and 1400

--4. Give all the employees in the RESEARCH department a 10% pay rise. 
--Verify that this has been done by listing all their details before and after the rise. 
--before
select * from emp where deptno = 
				(select deptno from dept where dname = 'Research')

update emp set salary = salary * 1.10 where deptno = 
				(select deptno from dept where dname = 'Research')
--after
select * from emp where deptno = 
				(select deptno from dept where dname = 'Research')

--5. Find the number of CLERKS employed. Give it a descriptive heading. 
select count(*) 'No of Clerks Employed' from emp where job = 'clerk'

--6. Find the average salary for each job type and the number of people employed in each job. 
select job 'Job Name', avg(salary) 'Average Salary', count(*) 'No of people' from emp 
group by job

--7. List the employees with the lowest and highest salary. 
select empno, ename, job, salary from emp where salary in(
				(select min(salary) from emp) , (select max(salary) from emp))

--8. List full details of departments that don't have any employees. 
select * from dept where deptno not in 
						(select distinct deptno from emp)

--9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name. 
select ename 'Employee Name', salary 'Employee Salary'from emp 
where job = 'analyst' and salary > 1200 and deptno = 20
order by ename

--10. For each department, list its name and number together with the total salary paid to employees in that department. 
select d.dname 'Department Name', d.deptno 'Department Number', sum(e.salary) from dept d, emp e
where d.deptno = e.deptno
group by d.deptno,d.dname

--11. Find out salary of both MILLER and SMITH.
select Ename, Salary from emp where ename = 'Miller' or ename = 'smith'

--12. Find out the names of the employees whose name begin with ‘A’ or ‘M’. 
select Ename 'Name' from emp where ename like '[AM]%' order by ename

--13. Compute yearly salary of SMITH. 
select ename 'Emp Name', (salary*12) 'Yearly Salary' from emp where ename = 'smith'

--14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 
select ename 'Employee Name', salary 'Salary' from emp
where salary not between 1500 and 2850
order by salary

--15. Find all managers who have more than 2 employees reporting to them
select e1.mgr_id 'Manager ID', e1.ename 'Manager Name', count(e2.ename) 'Reporting Count'
from emp e1 join emp e2
on e1.empno = e2.mgr_id 
group by e1.mgr_id, e1.ename
having count(e2.empno) > 2
