using System;

namespace Assignment_1
{
    class Assignment
    {
        public static void Question1()
        {
            // 1. Write a C# Sharp program to accept two integers and check whether they are equal or not. 
           
            Console.WriteLine("Question 1:");
            int num1, num2;
            Console.Write("Input 1st number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input 2nd number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            if (num1 == num2)
            {
                Console.WriteLine($"{num1} and {num2} are equal.");
            }
            else
            {
                Console.WriteLine($"{num1} and {num2} are not equal.");
            }
        }

        public static void Question2()
        {
            // 2. Write a C# Sharp program to check whether a given number is positive or negative. 

            int num;
            Console.WriteLine();
            Console.WriteLine("Question 2:");
            Console.Write("Enter a number: ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num > 0)
            {
                Console.WriteLine($"{num} is a positive number.");
            }
            else if (num < 0)
            {
                Console.WriteLine($"{num} is a negative number.");
            }
            else
            {
                Console.WriteLine("The number is zero");
            }
        }
        public static void Question3()
        {
            // 3. Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation.

            Console.WriteLine();
            Console.WriteLine("Question 3:");
            int num1, num2;
            char op;
            Console.Write("Input first number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input operation (+,-,*,/):");
            op = Convert.ToChar(Console.ReadLine());
            Console.Write("Input second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case '+':
                    Console.WriteLine($"{num1} {op} {num2} = {num1 + num2}");
                    break;
                case '-':
                    Console.WriteLine($"{num1} {op} {num2} = {num1 - num2}");
                    break;
                case '*':
                    Console.WriteLine($"{num1} {op} {num2} = {num1 * num2}");
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        Console.WriteLine($"{num1} {op} {num2} = {num1 / num2}");
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide with zero");
                    }
                    break;
                default:
                    Console.WriteLine("Please Enter a valid Operator");
                    break;
            }
        }
        public static void Question4()
        {
            // 4. Write a C# Sharp program that prints the multiplication table of a number as input.

            Console.WriteLine();
            Console.WriteLine("Question 4:");
            int num;
            Console.Write("Enter a number: ");
            num = Convert.ToInt32(Console.ReadLine());
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num} * {i} = {num * i}");
            }
        }
        public static void Question5()
        {
            // 5.  Write a C# program to compute the sum of two given integers. If two values are the same, return the triple of their sum.

            Console.WriteLine();
            Console.WriteLine("Question 5:");
            int num1, num2;
            Console.Write("Enter 1st number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter 2nd number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            int sum = (num1 == num2) ? (num1 + num2) * 3 : (num1 + num2);
            Console.WriteLine("The result is " + sum);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Assignment.Question1();
            Assignment.Question2();
            Assignment.Question3();
            Assignment.Question4();
            Assignment.Question5();
            Console.ReadLine();
        }
    }
}
