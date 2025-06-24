using System;

namespace Assignment_3
{
    //2. Create a class called student which has data members like rollno, name, class, Semester, branch, int[] marks = new int marks[5] (marks of 5 subjects )
    //-Pass the details of student like rollno, name, class, SEM, branch in constructor
    //-For marks write a method called GetMarks() and give marks for all 5 subjects
    //-Write a method called displayresult, which should calculate the average marks
    //-If marks of any one subject is less than 35 print result as failed
    //-If marks of all subject is >35,but average is < 50 then also print result as failed
    //-If avg > 50 then print result as passed.
    //-Write a DisplayData() method to display all object members values.

    class Student
    {
        int RollNo;
        string Name;
        int Class;
        int Semester;
        string Branch;
        int size = 5;
        int[] marks = new int[5];

        //passing values to constructor
        public Student(int rollno, string name, int classs, int semester, string branch)
        {
            RollNo = rollno;
            Name = name;
            Class = classs;
            Semester = semester;
            Branch = branch;
        }
        //taking user input marks with this method
        public void GetMarks()
        {
            for(int i = 0; i < size; i++)
            {
                Console.Write("Enter Marks of Subject {0}: ", i + 1);
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
            
        }
        //displaying the result
        public void DisplayResult()
        {
            int sum = 0;
            double average;
            int countlessthan35 = 0;
            foreach(int sub in marks)
            {
                sum += sub;
                if (sub < 35)
                {
                    countlessthan35 += 1;
                }
            }
            average = sum / size;
            if(countlessthan35>0 || average < 50)
            {
                Console.WriteLine("You Failed!");
            }
            else
            {
                Console.WriteLine("You Passed!");
            }
        }
        //displaying all the data
        public void DisplayData()
        {
            Console.WriteLine("\n------- Student Results -------");
            Console.WriteLine($"Roll Number = {RollNo}");
            Console.WriteLine($"Name = {Name}");
            Console.WriteLine($"Class = {Class}");
            Console.WriteLine($"Semester = {Semester}");
            Console.WriteLine($"Branch = {Branch}");
            Console.WriteLine("Marks: ");
            foreach(int sub in marks)
            {
                Console.Write(sub+" ");
            }
            Console.WriteLine();
            Console.WriteLine("Final Result: ");
            DisplayResult();
        }
    }
    class Inheritance2
    {
        static void Main()
        {
            int rollno;
            string name;
            int classs;
            int semester;
            string branch;

            Console.Write("Enter Roll Number: ");
            rollno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Class: ");
            classs = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Semester: ");
            semester = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Branch: ");
            branch = Console.ReadLine();
            
            //creating object
            Student student = new Student(rollno, name, classs, semester, branch);
            
            //calling the methods with object
            student.GetMarks();
            student.DisplayData();
            
            Console.ReadKey();
        }
    }
}
