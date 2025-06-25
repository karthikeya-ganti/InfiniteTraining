using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_1
{
    class CodeChallenge1
    {
        //Question 1
        public static void Question1()
        {
            //1.Write a C# Sharp program to remove the character at a given position in the string.
            //The given position will be in the range 0..(string length -1) inclusive.
            
            Console.WriteLine("----- Question 1 -----");
            string word;
            Console.Write("Enter a Word: ");
            word = Console.ReadLine();
            int position;
            Console.Write("Enter Position for Character Removal: ");
            position = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Result = {word.Remove(position, 1)}");
        }
        //Question 2
        public static void Question2()
        {
            //2.Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.
            
            Console.WriteLine("\n----- Question 2 -----");
            string str;
            Console.Write("Enter the string: ");
            str = Console.ReadLine();
            StringBuilder newstr = new StringBuilder(str);
            char last = str[str.Length - 1];
            char first = str[0];
            newstr.Replace(first, last, 0, 1);
            newstr.Replace(last, first, str.Length - 1, 1);
            Console.WriteLine($"String after Exchanging = {newstr}");
        }
        // Question 3
        public static void Question3()
        {
            //3. Write a C# Sharp program to check the largest number among three given integers.

            Console.WriteLine("\n----- Question 3 -----");
            int num1, num2, num3;
            Console.Write("Enter Number 1: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number 2: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number 3: ");
            num3 = Convert.ToInt32(Console.ReadLine());
            if(num1>num2 && num1 > num3)
            {
                Console.WriteLine("The largest = " + num1);
            }
            else if (num2 > num3)
            {
                Console.WriteLine("The largest = " + num2);
            }
            else
            {
                Console.WriteLine("The largest = " + num3);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CodeChallenge1.Question1();
            CodeChallenge1.Question2();
            CodeChallenge1.Question3();
            Console.ReadKey();
        }
    }
}
