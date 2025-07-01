using System;
using System.Collections.Generic;

namespace Assignment_4
{
    //Question 1
    //Scenario: Employee Management System(Console-Based)
    //-----------------------------------------------------
    //You are tasked with developing a simple console-based Employee Management System using C# that allows users to manage a list of employees. Use a menu-driven approach to perform CRUD operations on a List<Employee>.
    //Each Employee has the following properties:
    //int Id
    //string Name
    //string Department
    //double Salary
    // Functional Requirements
    //Design a menu that repeatedly prompts the user to choose one of the following actions:
    //===== Employee Management Menu =====
    //1. Add New Employee
    //2. View All Employees
    //3. Search Employee by ID
    //4. Update Employee Details
    //5. Delete Employee
    //6. Exit
    //====================================
    //Enter your choice:
    // Task:
    //Write a C# program using:
    //A class Employee with the above properties.
    //A List<Employee> to hold all employee records.
    //A menu-based loop to allow the user to perform the following:
    //✅ Expected Functionalities (CRUD)
    //1.Prompt the user to enter details for a new employee and add it to the list.
    //2.Display all employees 
    //3.Allow searching an employee by Id and display their details.
    //4.Search for an employee by Id, and if found, allow the user to update name, department, or salary.
    //5.Search for an employee by Id and remove the employee from the list.
    //6.Cleanly exit the program.
    //Use Exception handling Mechanism

    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        List<Employee> EmployeeList = new List<Employee>();

        internal void AddEmployee(Employee employee)
        {
            EmployeeList.Add(employee);
        }

        internal List<Employee> DisplayEmployees()
        {
            return EmployeeList;
        }

        internal void GetEmployeeById(int empid)
        {
            foreach (var employee in EmployeeList)
            {
                try
                {
                    if (employee.EmpId == empid)
                    {
                        Console.WriteLine($"Employee Id = {employee.EmpId}");
                        Console.WriteLine($"Employee Name = {employee.EmpName}");
                        Console.WriteLine($"Employee Departmemt = {employee.Department}");
                        Console.WriteLine($"Employee Salary = {employee.Salary}");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Employee Id!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error Occured {0}", e.Message);
                }
            }
        }
        internal void UpdateEmployeeById(int empid)
        {
            foreach (var employee in EmployeeList)
            {
                try
                {
                    if (employee.EmpId == empid)
                    {
                        int option;
                        Console.Write("Enter details to Update: ");
                        Console.Write("1. Name\t2. Department\t3. Salary: ");
                        option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.Write("Enter New Employee Name: ");
                                employee.EmpName = Console.ReadLine();
                                Console.WriteLine("Employee name updated successfully!");
                                break;
                            case 2:
                                Console.Write("Enter New Employee Department: ");
                                employee.Department = Console.ReadLine();
                                Console.WriteLine("Employee name updated successfully!");
                                break;
                            case 3:
                                Console.Write("Enter New Employee Salary: ");
                                employee.Salary = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Employee name updated successfully!");
                                break;
                            default:
                                Console.WriteLine("Incorrect Option Entered!!");
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error Occured {0}",e.Message);
                }
            }
        }
        internal void RemoveEmployeeById(int empid)
        {
            try
            {
                for (int i = 0; i < EmployeeList.Count; i++)
                {
                    if (EmployeeList[i].EmpId == empid)
                    {
                        EmployeeList.RemoveAt(i);
                        Console.WriteLine("Employee is Successfully Removed!");
                        return;
                    }
                }
                Console.WriteLine("No Such Employee Id!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occured {0}", e.Message);
            }
        }

    }
    class EmployeeMain
    {
        static void Main()
        {
            Employee employee = new Employee();

            List<Employee> employeedata = new List<Employee>();
            bool server = true;
            while (server)
            {
                int select;
                Console.WriteLine("\n===== Employee Management Menu =====");
                Console.WriteLine("1.Add New Employee");
                Console.WriteLine("2.View All Employees");
                Console.WriteLine("3.Search Employee by ID");
                Console.WriteLine("4.Update Employee Details");
                Console.WriteLine("5.Delete Employee");
                Console.WriteLine("6.Exit");
                Console.WriteLine("====================================");
                select = Convert.ToInt32(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        Console.WriteLine("Enter New Employee Details: ");
                        int id;
                        Console.Write("Enter Employee Id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        string name;
                        Console.Write("Enter Employee Name: ");
                        name = Console.ReadLine();
                        string department;
                        Console.Write("Enter Employee Department: ");
                        department = Console.ReadLine();
                        double salary;
                        Console.Write("Enter Employee Salary: ");
                        salary = Convert.ToDouble(Console.ReadLine());

                        employee.AddEmployee(new Employee { EmpId = id, EmpName = name, Department = department, Salary = salary });
                        Console.WriteLine("Employee Details Added Successfully");
                        break;
                    case 2:
                        employeedata = employee.DisplayEmployees();
                        Console.WriteLine("------------------Display Employee ---------------------");
                        foreach (var item in employeedata)
                        {
                            Console.WriteLine($"ID:{item.EmpId + " " + item.EmpName + " " + item.Department + " " + item.Salary }");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Searching Employee Data by Id");
                        Console.Write("Enter Id to Search: ");
                        int searchid = Convert.ToInt32(Console.ReadLine());
                        employee.GetEmployeeById(searchid);
                        break;
                    case 4:
                        Console.WriteLine("Updating Employee Data with Id");
                        Console.Write("Enter Id to Update Data: ");
                        int updateid = Convert.ToInt32(Console.ReadLine());
                        employee.UpdateEmployeeById(updateid);
                        break;
                    case 5:
                        Console.WriteLine("Removing Employee Data with Id");
                        Console.Write("Enter Id to Remove Data: ");
                        int removeid = Convert.ToInt32(Console.ReadLine());
                        employee.RemoveEmployeeById(removeid);
                        break;
                    case 6:
                        server = false;
                        break;
                    default:
                        Console.WriteLine("Enter Valid Option!!");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
