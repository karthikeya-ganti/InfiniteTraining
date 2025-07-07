using System;
using System.IO;

namespace Assignment_6
{
    // Question 2
    // 2. Write a program in C# Sharp to create a file and write an array of strings to the file.
    class Question_2
    {
        static void Main()
        {
            string filename;
            Console.Write("Enter the file name with extension to create: ");
            filename = Console.ReadLine();                                  // We can give path too            
            Console.WriteLine("Note: The file has been created inside the \"Project_Name/bin/Debug\" path." + filename);    // this is the default path

            int strcount;
            Console.Write("Enter the no. of strings to store in the file: ");
            int.TryParse(Console.ReadLine(), out strcount);

            string[] fileinput = new string[strcount];          // Creating an array of strings to store the user input
            for(int i = 0; i < strcount; i++)
            {
                Console.Write($"Enter Line {i + 1}: ");
                fileinput[i] = Console.ReadLine();
            }
            
            File.WriteAllLines(filename, fileinput);            // Here the file will be created (opened if it exists before) and writes all lines of the input into the file
            Console.WriteLine("File is successfully created and the Input is entered.");

            Console.WriteLine("The Data inside the file {0} is: ", filename);
            string[] filedata = File.ReadAllLines(filename);        // Reading the data inside the file

            foreach (var v in filedata)
            {
                Console.WriteLine(v);
            }
            Console.ReadKey();
        }
    }
}
