using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    // Question 1
    // 1. Write a query that returns list of numbers and their squares only if square is greater than 20 
    class Question_1
    {
        static void Main()
        {
            int inputSize = 0;
            Console.Write("Enter no of elements: ");
            try
            {
                inputSize = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            List<int> inputList = new List<int>();
            for(int i = 0; i < inputSize; i++)
            {
                Console.Write("Enter {0} element: ", i + 1);
                int value = Convert.ToInt32(Console.ReadLine());
                inputList.Add(value);
            }
            int minSquareValue;
            Console.Write("\nEnter minimum square value to filter: ");
            minSquareValue = Convert.ToInt32(Console.ReadLine());

            IEnumerable<int> squaresGreaterThanMinimum = from input in inputList
                                                         where (input * input) > minSquareValue
                                                         select input;

            Console.WriteLine("\nAfter performing Query....");
            Console.WriteLine("\nThe numbers whose squares are greater than {0} are: ", minSquareValue);
            foreach(var v in squaresGreaterThanMinimum)
            {
                Console.WriteLine($"{v} - {v*v}");
            }
            Console.ReadKey();
        }
    }
}
