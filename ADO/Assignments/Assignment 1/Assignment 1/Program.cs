using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_1
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
        public Employee(int id, string fname, string lname, string titlee, DateTime dateob, DateTime dateoj, string cityy)
        {
            EmployeeID = id;
            FirstName = fname;
            LastName = lname;
            Title = titlee;
            DOB = dateob;
            DOJ = dateoj;
            City = cityy;
        }
    }

    class EmployeeList
    {
        List<Employee> employees = new List<Employee>();
        public void EmployeeData()
        {
            var empList = new EmployeeList();
            employees.Add(new Employee(1001, "Malcolm", "Daruwalla", "Manager", Convert.ToDateTime("16-11-1984"), Convert.ToDateTime("08-06-2011"), "Mumbai"));
            employees.Add(new Employee(1002, "Asdin", "Dhalla", "AsstManager", Convert.ToDateTime("20-08-1984"), Convert.ToDateTime("07-07-2012"), "Mumbai"));
            employees.Add(new Employee(1003, "Madhavi", "Oza", "Consultant", Convert.ToDateTime("14-11-1987"), Convert.ToDateTime("12-04-2015"), "Pune"));
            employees.Add(new Employee(1004, "Saba", "Shaikh", "SE", Convert.ToDateTime("03-06-1990"), Convert.ToDateTime("02-02-2016"), "Pune"));
            employees.Add(new Employee(1005, "Nazia", "Shaikh", "SE", Convert.ToDateTime("08-03-1991"), Convert.ToDateTime("02-02-2016"), "Mumbai"));
            employees.Add(new Employee(1006, "Amit", "Pathak", "Consultant", Convert.ToDateTime("07-11-1989"), Convert.ToDateTime("08-08-2014"), "Chennai"));
            employees.Add(new Employee(1007, "Vijay", "Natrajan", "Consultant", Convert.ToDateTime("02-12-1989"), Convert.ToDateTime("01-06-2015"), "Mumbai"));
            employees.Add(new Employee(1008, "Rahul", "Dubey", "Associate", Convert.ToDateTime("11-11-1993"), Convert.ToDateTime("06-11-2014"), "Chennai"));
            employees.Add(new Employee(1009, "Suresh", "Mistry", "Associate", Convert.ToDateTime("12-08-1992"), Convert.ToDateTime("03-12-2014"), "Chennai"));
            employees.Add(new Employee(1010, "Sumit", "Shah", "Manager", Convert.ToDateTime("12-04-1991"), Convert.ToDateTime("02-01-2016"), "Pune"));
        }
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        public void Display(List<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"Employee ID: {emp.EmployeeID}, {emp.FirstName} {emp.LastName}, {emp.Title}, {emp.DOB.ToString()}, {emp.DOJ.ToString()}, {emp.City}");
            }
        }
        public List<Employee> GetEmployees()
        {
            return employees;
        }

    }

    class Program
    {
        static void Main()
        {
            EmployeeList employees = new EmployeeList();
            employees.EmployeeData();

            var employeeList = employees.GetEmployees();

            //employeeList.Display(employees);

            //1.Display a list of all the employee who have joined before 1 / 1 / 2015
            Console.WriteLine("\n----- Query 1 -----");
            var empJoinedBefore2015 = employeeList.Where(e => e.DOJ < new DateTime(2015, 1, 1)).ToList();
            Console.WriteLine("Employees Joined before 1/1/2015: ");
            employees.Display(empJoinedBefore2015);

            //2.Display a list of all the employee whose date of birth is after 1 / 1 / 1990
            Console.WriteLine("\n----- Query 2 -----");
            var empBornAfter1990 = employeeList.Where(e => e.DOB > new DateTime(1990, 1, 1)).ToList();
            Console.WriteLine("Employees Born after 1/1/1990: ");
            employees.Display(empBornAfter1990);

            //3.Display a list of all the employee whose designation is Consultant and Associate
            Console.WriteLine("\n----- Query 3 -----");
            var empConsoltantorAssociate = employeeList.Where(e => e.Title == "Consultant" || e.Title == "Associate").ToList();
            Console.WriteLine("Employees having title Consultant or Associate: ");
            employees.Display(empConsoltantorAssociate);

            //4.Display total number of employees
            Console.WriteLine("\n----- Query 4 -----");
            var empCount = employeeList.Count();
            Console.WriteLine("Total number of Employees: " + empCount);

            //5.Display total number of employees belonging to “Chennai”
            Console.WriteLine("\n----- Query 5 -----");
            var empFromChennai = employeeList.Where(e => e.City == "Chennai").ToList();
            Console.WriteLine("Employees from Chennai: ");
            employees.Display(empFromChennai);

            //6.Display highest employee id from the list
            Console.WriteLine("\n----- Query 6 -----");
            var empIdMax = employeeList.Max(e => e.EmployeeID);
            Console.WriteLine("Highest Employee ID: " + empIdMax);

            //7.Display total number of employee who have joined after 1 / 1 / 2015
            Console.WriteLine("\n----- Query 7 -----");
            var empAfter2015Count = employeeList.Where(e => e.DOJ > new DateTime(2015, 1, 1)).ToList().Count();
            Console.WriteLine("Total number of employees joined after 1/1/2015: " + empAfter2015Count);

            //8.Display total number of employee whose designation is not “Associate”
            Console.WriteLine("\n----- Query 8 -----");
            var empNotAssociate = employeeList.Where(e => e.Title != "Associate").ToList().Count();
            Console.WriteLine("Total number of employee who is not Associate: " + empNotAssociate);

            //9.Display total number of employee based on City
            Console.WriteLine("\n----- Query 9 -----");
            var empByCity = employeeList.GroupBy(e => e.City).Select(c => new { city = c.Key, cityEmpCount = c.Count() });
            Console.WriteLine("Employees based on City: ");
            foreach(var city in empByCity)
            {
                Console.WriteLine($"City: {city.city}, Employee Count: {city.cityEmpCount}");
            }

            //10.Display total number of employee based on city and title
            Console.WriteLine("\n----- Query 10 -----");
            var empByCityTitle = employeeList.GroupBy(e => (e.City, e.Title)).Select(ct => new { city = ct.Key.City, title = ct.Key.Title, cityTitleEmpCount = ct.Count() });
            Console.WriteLine("Employees based on City: ");
            foreach (var ct in empByCityTitle)
            {
                Console.WriteLine($"City: {ct.city}, Title: {ct.title}, Employee Count: {ct.cityTitleEmpCount}");
            }

            //11.Display total number of employee who is youngest in the list
            Console.WriteLine("\n----- Query 11 -----");
            var youngestEmp = employeeList.Max(e => e.DOB);
            var youngEmpCount = employeeList.Count(e => e.DOB == youngestEmp);
            Console.WriteLine($"Youngest Employee DOB: {youngestEmp}, Total Count: {youngEmpCount}");

            Console.ReadKey();
        }
    }
}
