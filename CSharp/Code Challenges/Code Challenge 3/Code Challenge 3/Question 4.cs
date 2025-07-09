using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_3
{
    //4. Write a console program that uses delegate object as an argument to call Calculator Functionalities like 
    //1. Addition, 2. Subtraction and 3. Multiplication by taking 2 integers and returning the output to the user. 
    //You should display all the return values accordingly.
    delegate int Calculator(int a, int b);
    class Question_4
    {
        static int Add(int num1, int num2) => num1 + num2;
        static int Subtract(int num1, int num2) => num1 - num2;
        static int Multiply(int num1, int num2) => num1 * num2;
        static int Divide(int num1, int num2)
        {
            if(num2 == 0)
            {
                Console.WriteLine("Division with zero is not defined.");
                return 0;
            }
            return num1 / num2;
        }
        static void Main()
        {
            Console.WriteLine("----- Question 4 -----");
            Console.Write("Enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Calculator result;
            bool calculating = true;
            while (calculating)
            {
                Console.WriteLine("\n1. Addition\t 2. Subtraction\t 3. Multiplication\t 4. Division\t 5. Exit");
                Console.Write("Enter the option: ");
                int option;
                option = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (option)
                {
                    case 1:
                        result = Add;
                        Console.WriteLine($"Addition: {num1} + {num2} = {result(num1,num2)}");
                        break;
                    case 2:
                        result = Subtract;
                        Console.WriteLine($"Subtraction: {num1} - {num2} = {result(num1, num2)}");
                        break;
                    case 3:
                        result = Multiply;
                        Console.WriteLine($"Multiplication: {num1} * {num2} = {result(num1, num2)}");
                        break;
                    case 4:
                        result = Divide;
                        Console.WriteLine($"Division: {num1} / {num2} = {result(num1, num2)}");
                        break;
                    case 5:
                        calculating = false;
                        break;
                    default:
                        Console.WriteLine("Enter valid option!");
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
