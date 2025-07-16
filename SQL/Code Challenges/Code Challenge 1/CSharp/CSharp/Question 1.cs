using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp
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
        public Employee(int id,string fname, string lname, string titlee, DateTime dateob, DateTime dateoj, string cityy)
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
    class Question_1
    {
        static void Main()
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee(1001, "Malcolm", "Daruwalla", "Manager", Convert.ToDateTime("16-11-1984"), Convert.ToDateTime("08-06-2011"), "Mumbai"),
                new Employee(1002, "Asdin", "Dhalla", "AsstManager", Convert.ToDateTime("20-08-1994"), Convert.ToDateTime("07-07-2012"), "Mumbai"),
                new Employee(1003, "Madhavi", "Oza", "Consultant", Convert.ToDateTime("14-11-1987"), Convert.ToDateTime("12-04-2015"), "Pune"),
                new Employee(1004, "Saba", "Shaikh", "SE", Convert.ToDateTime("03-06-1990"), Convert.ToDateTime("02-02-2016"), "Pune"),
                new Employee(1005, "Nazia", "Shaikh", "SE", Convert.ToDateTime("08-03-1991"), Convert.ToDateTime("02-02-2016"), "Mumbai"),
                new Employee(1006, "Amit", "Pathak", "Consultant", Convert.ToDateTime("07-11-1989"), Convert.ToDateTime("08-08-2014"), "Chennai"),
                new Employee(1007, "Vijay", "Natrajan", "Consultant", Convert.ToDateTime("02-12-1989"), Convert.ToDateTime("01-06-2015"), "Mumbai"),
                new Employee(1008, "Rahul", "Dubey", "Associate", Convert.ToDateTime("11-11-1993"), Convert.ToDateTime("06-11-2014"), "Chennai"),
                new Employee(1009, "Suresh", "Mistry", "Associate", Convert.ToDateTime("12-08-1992"), Convert.ToDateTime("03-12-2014"), "Chennai"),
                new Employee(1010, "Sumit", "Shah", "Manager", Convert.ToDateTime("12-04-1991"), Convert.ToDateTime("02-01-2016"), "Pune")
            };
            //Query 1
            //a.Display detail of all the employee
            var displayallemployee = empList.ToList();

            Console.WriteLine("Query 1");
            foreach (var emp in displayallemployee)
            {
                Console.WriteLine($"{emp.EmployeeID}, {emp.FirstName} {emp.LastName}, {emp.Title}, {emp.DOB.ToString()}, {emp.DOJ.ToString()}, {emp.City}");
            }

            //Query 2
            //b.Display details of all the employee whose location is not Mumbai
            var employeelocationnotmumbai = empList.FindAll(e => e.City != "Mumbai");
            Console.WriteLine("\nQuery 2");
            foreach (var emp in employeelocationnotmumbai)
            {
                Console.WriteLine($"{emp.EmployeeID}, {emp.FirstName} {emp.LastName}, {emp.Title}, {emp.DOB.ToString()}, {emp.DOJ.ToString()}, {emp.City}");
            }

            //Query 3
            //c. Display details of all the employee whose title is AsstManager
            var employeetitleasstmanager = empList.FindAll(e => e.Title == "AsstManager");
            Console.WriteLine("\nQuery 3");
            foreach (var emp in employeetitleasstmanager)
            {
                Console.WriteLine($"{emp.EmployeeID}, {emp.FirstName} {emp.LastName}, {emp.Title}, {emp.DOB.ToString()}, {emp.DOJ.ToString()}, {emp.City}");
            }

            //Query 4
            //d. Display details of all the employee whose Last Name start with S
            var employeelastnames = empList.FindAll(e => e.LastName.StartsWith("S"));
            Console.WriteLine("\nQuery 4");
            foreach (var emp in employeelastnames)
            {
                Console.WriteLine($"{emp.EmployeeID}, {emp.FirstName} {emp.LastName}, {emp.Title}, {emp.DOB.ToString()}, {emp.DOJ.ToString()}, {emp.City}");
            }

            Console.ReadKey();
        }
    }
}
