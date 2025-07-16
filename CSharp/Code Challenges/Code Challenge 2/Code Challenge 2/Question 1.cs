using System;

namespace Code_Challenge_2
{
    //Question 1
    //1. Create an Abstract class Student with Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade)
    //which takes grade as an input and checks whether student passed the course or not
    //Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student and overrides Ispassed(grade) method
    //For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false.
    //For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.
    //Test the above by creating appropriate objects
    class IncorrectClassException : ApplicationException
    {
        public IncorrectClassException(string message) : base(message)
        {
            Console.WriteLine("Incorrect Class Mentioned!!");
        }
    }
    abstract class Student
    {
        public string StudentName { get; set; }
        public int StudentId { get; set; }
        public double StudentGrade { get; set; }
        public abstract bool IsPassed(double grade);
    }

    class UnderGraduate : Student
    {
        public UnderGraduate(string name, int id, double grade)
        {
            StudentName = name;
            StudentId = id;
            StudentGrade = grade;
        }
        public override bool IsPassed(double grade)
        {
            double mingrade = 70.0;
            if (StudentGrade >= mingrade)
            {
                return true;
            }
            return false;
        }

    }

    class Graduate : Student
    {
        public Graduate(string name, int id, double grade)
        {
            StudentName = name;
            StudentId = id;
            StudentGrade = grade;
        }
        public override bool IsPassed(double grade)
        {
            double mingrade = 80.0;
            if (StudentGrade >= mingrade)
            {
                return true;
            }
            return false;
        }
    }
    class Question_1
    {
        static void Main()
        {
            Console.WriteLine("----- Question 1 -----");
            string studentname;
            Console.Write("Enter Student Name: ");
            studentname = Console.ReadLine();
            
            int studentid;
            Console.Write("Enter Student Id: ");
            studentid = Convert.ToInt32(Console.ReadLine());
            
            double studentgrade;
            Console.Write("Enter Student Grade: ");
            studentgrade = Convert.ToDouble(Console.ReadLine());

            char studentclass = '\0';
            Console.Write("Enter your Class (U - UnderGraduate, G - Graduate): ");
            try
            {
                studentclass = Convert.ToChar(Console.ReadLine());
            }
            catch(IncorrectClassException e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
            if (studentclass == 'U' || studentclass == 'u')
            {
                UnderGraduate ugstudent = new UnderGraduate(studentname, studentid, studentgrade);
                if (ugstudent.IsPassed(studentgrade))
                    Console.WriteLine("You are Passed!");
                else
                    Console.WriteLine("You are Failed!");
            }
            else if (studentclass == 'G' || studentclass == 'g')
            {
                Graduate gradstudent = new Graduate(studentname, studentid, studentgrade);
                if (gradstudent.IsPassed(studentgrade))
                    Console.WriteLine("You are Passed!");
                else
                    Console.WriteLine("You are Failed!");
            }
            else
            {
                Console.WriteLine("No such Class!");
                throw new IncorrectClassException("No class");
            }
            Console.ReadKey();
        }
    }
}
