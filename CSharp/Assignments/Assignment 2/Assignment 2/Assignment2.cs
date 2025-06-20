using System;

namespace Assignment_2
{
    class Assignment2
    {
        public static void Question1()
        {
            //1. Write a C# Sharp program to swap two numbers.

            Console.WriteLine("Question 1: ");
            int num1, num2;
            Console.Write("Enter first number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Before swapping: num1 = {0}, num2 = {1}", num1, num2);
            //swapping
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
            Console.WriteLine("After swapping: num1 = {0}, num2 = {1}", num1, num2);
        }
        public static void Question2()
        {
            //2. Write a C# program that takes a number as input and displays it four times in a row (separated by blank spaces), and then four times in the next row, with no separation.
            // You should do it twice: Use the console. Write and use {0}.

            Console.WriteLine();
            Console.WriteLine("Question 2: ");
            int num;
            Console.Write("Enter a number: ");
            num = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < 2; i++)
            {
                Console.WriteLine("{0} {0} {0} {0}",num); //displaying 4 times with spaces
                Console.WriteLine("{0}{0}{0}{0}", num); //displaying 4 times without spaces
            }
        }

        enum Days
        {
            Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }
        public static void Question3()
        {
            //3. Write a C# Sharp program to read any day number as an integer and display the name of the day as a word.

            Console.WriteLine();
            Console.WriteLine("Question 3: ");
            int daynumber;
            Console.Write("Enter a day number (1 - 7): ");
            daynumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Enum.GetName(typeof(Days),daynumber));
        }
        public static void Arrays1()
        {
            //1. Write a  Program to assign integer values to an array  and then print the following
            //   a.Average value of Array elements
            //   b.Minimum and Maximum value in an array

            Console.WriteLine();
            Console.WriteLine("Arrays 1: ");
            int size;
            Console.Write("Enter size of the array: ");
            size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            for(int i = 0; i < size; i++) 
            {
                Console.Write($"Enter {i+1} element: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int minimum, maximum;
            double average;
            int sum;
            sum = 0;
            minimum = arr[0];
            maximum = arr[0];
            
            foreach(int num in arr)
            {
                sum += num;
                if (minimum > num)
                {
                    minimum = num;
                }
                if (maximum < num)
                {
                    maximum = num;
                }
            }
            average = sum / size;
            Console.WriteLine($"Average of the array is: {average}");
            Console.WriteLine($"Minimum of the array is: {minimum}");
            Console.WriteLine($"Maximum of the array is: {maximum}");
        }
        public static void Arrays2()
        {
            //2.Write a program in C# to accept ten marks and display the following
            //    a.Total
            //    b.Average
            //    c.Minimum marks
            //    d.Maximum marks
            //    e.Display marks in ascending order
            //    f.Display marks in descending order

            Console.WriteLine();
            Console.WriteLine("Arrays 2: ");
            int size = 10;
            int[] marks = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter Marks {i+1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
            int total = 0;
            double average;

            foreach (int num in marks)
            {
                total += num;
            }
            average = total / size;

            Array.Sort(marks);

            Console.WriteLine($"Total Marks: {total}");
            Console.WriteLine($"Average Marks: {average}");
            Console.WriteLine($"Minimum Marks: {marks[0]}");
            Console.WriteLine($"Maximum Marks: {marks[size-1]}");
            Console.WriteLine("Marks in ascending order: ");
            foreach(int num in marks)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Array.Reverse(marks);
            Console.WriteLine("Marks in descending order: ");
            foreach (int num in marks)
            {
                Console.Write(num + " ");
            }
        }
        public static void Arrays3()
        {
            //3.  Write a C# Sharp program to copy the elements of one array into another array.(do not use any inbuilt functions)
            Console.WriteLine();
            Console.WriteLine("Arrays 3: ");
            int size;
            Console.Write("Enter size of the array: ");
            size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter {i + 1} element: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Displaying original Array: ");
            foreach(int num in arr)
            {
                Console.Write(num + " ");
            }
            int[] arrcopy = new int[size];
            for(int i = 0; i < size; i++)
            {
                arrcopy[i] = arr[i];
            }
            Console.WriteLine();
            Console.WriteLine("Displaying Copied Array: ");
            foreach (int num in arrcopy)
            {
                Console.Write(num + " ");
            }
        }
        public static void Strings1()
        {
            //1.Write a program in C# to accept a word from the user and display the length of it.
            Console.WriteLine();
            Console.WriteLine("Strings 1: ");
            string word;
            Console.Write("Enter a word: ");
            word = Console.ReadLine();
            int length;
            length = word.Length;
            Console.WriteLine($"Length of the word is: {length}");
        }
        public static void Strings2()
        {
            //2.Write a program in C# to accept a word from the user and display the reverse of it.
            Console.WriteLine();
            Console.WriteLine("Strings 2: ");
            string word;
            Console.Write("Enter a word: ");
            word = Console.ReadLine();
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);
            Console.WriteLine("Reversed word: " + reversed);
        }
        public static void Strings3()
        {
            //3.	Write a program in C# to accept two words from user and find out if they are same. 
            Console.WriteLine();
            Console.WriteLine("Strings 3: ");
            string str1;
            Console.Write("Enter first word: ");
            str1 = Console.ReadLine();
            string str2;
            Console.Write("Enter second word: ");
            str2 = Console.ReadLine();
            if (str1 == str2)
            {
                Console.WriteLine("The two words are same.");
            }
            else
            {
                Console.WriteLine("The two words are different.");
            }
        }
        static void Main(string[] args)
        {
            Assignment2.Question1();
            Assignment2.Question2();
            Assignment2.Question3();
            Assignment2.Arrays1();
            Assignment2.Arrays2();
            Assignment2.Arrays3();
            Assignment2.Strings1();
            Assignment2.Strings2();
            Assignment2.Strings3();
            Console.ReadKey();       
        }
    }
}
