using System;
using System.IO;

namespace Assignment_6
{
    // Question 3
    // 3. Write a program in C# Sharp to count the number of lines in a file.
    class Question_3
    {
        static void Main()
        {
            string filepath;
            Console.Write("Enter the file name with path: ");
            filepath = Console.ReadLine();

            int countlines;
            string[] filedata = File.ReadAllLines(filepath);    // Converting each line in a file into a string
            countlines = filedata.Length;                       // Counting the length which results in no of lines
          
            Console.WriteLine("This file contains {0} lines!", countlines);
            
            Console.ReadKey();
        }
    }
}
