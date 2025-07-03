using System;

namespace Assignment_5
{
    //2. Create a class called Scholarship which has a function Public void Merit() that takes marks and fees as an input.
    //If the given mark is >= 70 and <=80, then calculate scholarship amount as 20% of the fees
    //If the given mark is > 80 and <=90, then calculate scholarship amount as 30% of the fees
    //If the given mark is >90, then calculate scholarship amount as 50% of the fees.
    //In all the cases return the Scholarship amount, else throw an user exception

    // user defined exception
    class NoScholarshipException : ApplicationException
    {
        public NoScholarshipException(string message) : base(message)
        {
            Console.WriteLine("\n\tError \nScholarship is not Applicable!!");
        }
    }

    class Scholarship
    {
        public double Merit(int marks, double fees)
        {
            double scholarshipAmount = 0;
            if (marks > 90)
            {
                scholarshipAmount = 0.5 * fees;
            }
            else if(marks>80 && marks <= 90)
            {
                scholarshipAmount = 0.3 * fees;
            }
            else if(marks>=70 && marks <= 80)
            {
                scholarshipAmount = 0.2 * fees;
            }
            else
            {
                throw new NoScholarshipException("Marks obtained is less than 70.");
            }
            return scholarshipAmount;
        }
    }
    class Question_2
    {
        static void Main()
        {

            int marks = 0;
            Console.Write("Enter Marks: ");
            try
            {
                marks = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            double fees = 0;
            Console.Write("Enter Fees: ");
            try
            {
                fees = double.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            Scholarship scholarship = new Scholarship();
            double scholarshipAmount = 0;
            
            try
            {
                scholarshipAmount = scholarship.Merit(marks, fees);
            }
            catch (NoScholarshipException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("The Scholarship Amount = " + scholarshipAmount);

            Console.ReadKey();
        }
    }
}