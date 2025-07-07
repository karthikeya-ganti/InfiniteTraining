using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    // 3.Create a list of employees with following property EmpId, EmpName, EmpCity, EmpSalary.Populate some data
    // Write a program for following requirement
    // a.To display all employees data
    // b.To display all employees data whose salary is greater than 45000
    // c.To display all employees data who belong to Bangalore Region
    // d.To display all employees data by their names is Ascending order
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public int EmpSalary { get; set; }
        public Employee(int EmpId, string EmpName, string EmpCity, int EmpSalary)
        {
            this.EmpId = EmpId;
            this.EmpName = EmpName;
            this.EmpCity = EmpCity;
            this.EmpSalary = EmpSalary;
        }
    }
    class Question_3
    {
        public static void DisplayEmployee(List<Employee> empdata)
        {
            foreach(var v in empdata)
            {
                Console.WriteLine($"Id = {v.EmpId} Name = {v.EmpName} City = {v.EmpCity} Salary = {v.EmpSalary}");
            }
        }
        static void Main()
        {

            List<Employee> empData = new List<Employee>();

            Console.Write("Enter no of employees working: ");
            int empCount = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < empCount; i++)
            {

                Console.Write($"Enter Employee {i + 1} Id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Enter Employee {i + 1} Name: ");
                string name = (Console.ReadLine());
                Console.Write($"Enter Employee {i + 1} City: ");
                string city = (Console.ReadLine());
                Console.Write($"Enter Employee {i + 1} Salary: ");
                int salary = Convert.ToInt32(Console.ReadLine());
                Employee newEmployee = new Employee(id, name, city, salary);
                empData.Add(newEmployee);
                
            }
            bool looping = true;
            while (looping)
            {
                Console.WriteLine("\na. To display all employees data \nb. To display all employees data whose salary is greater than desired salary \nc. To display all employees data who belong to Desired Region \nd. To display all employees data by their names is Ascending order \ne. To exit.");
                Console.Write("\nEnter the option: ");
                char option = Convert.ToChar(Console.ReadLine());
                switch (option)
                {
                    case 'a':
                    case 'A':
                        // a.To display all employees data
                        DisplayEmployee(empData);
                        break;

                    case 'b':
                    case 'B':
                        // b.To display all employees data whose salary is greater than 45000
                        Console.Write("Enter the desired salary point: ");
                        int minSalary = Convert.ToInt32(Console.ReadLine());
                        List<Employee> employeeGreaterThanDesiredSalary = empData.FindAll(emp => emp.EmpSalary > minSalary);
                        DisplayEmployee(employeeGreaterThanDesiredSalary);
                        break;

                    case 'c':
                    case 'C':
                        // c.To display all employees data who belong to Bangalore Region
                        Console.Write("Enter the desired location: ");
                        string location = Console.ReadLine().ToLower();
                        List<Employee> employeeFromLocation = empData.FindAll(emp => emp.EmpCity.ToLower() == location);
                        DisplayEmployee(employeeFromLocation);
                        break;

                    case 'd':
                    case 'D':
                        // d.To display all employees data by their names is Ascending order
                        var sortedByName = empData.OrderBy(emp => emp.EmpName).ToList();
                        DisplayEmployee(sortedByName);
                        break;

                    case 'e':
                    case 'E':
                        looping = false;
                        break;

                    default:
                        Console.WriteLine("Enter the correct option!");
                        break;
                }
            }           
        }
    }
}
