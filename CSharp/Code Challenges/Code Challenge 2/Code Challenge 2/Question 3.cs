using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_2
{
    //3. Write a C# program to implement a method that takes an integer as input
    //and throws an exception if the number is negative. Handle the exception in the calling code.
    class NegativeException : ApplicationException
    {
        public NegativeException(string message) : base(message)
        {
            Console.WriteLine("Error!! Negative number is Invalid!!");
        }
    }
    class Question_3
    {
        public static void IntegerInputMethod(int num)
        {
            if (num < 0)
                throw new NegativeException("Incorrect Input");
            else
                Console.WriteLine("You entered " + num);
        }
        static void Main()
        {
            Console.WriteLine("----- Question 3 -----");
            int num;
            Console.Write("Enter an Integer: ");
            num = Convert.ToInt32(Console.ReadLine());
            try
            {
                IntegerInputMethod(num);
            }
            catch(NegativeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
