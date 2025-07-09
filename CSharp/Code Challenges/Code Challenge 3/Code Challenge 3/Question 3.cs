using System;
using System.IO;

namespace Code_Challenge_3
{
    //3. Write a program in C# Sharp to append some text to an existing file.
    //If file is not available, then create one in the same workspace.
    //Hint: (Use the appropriate mode of operation.Use stream writer class)
    class Question_3
    {
        static void Main()
        {
            string filepath;
            Console.Write("Enter the file path: ");
            filepath = Console.ReadLine();

            string text_to_append;
            Console.WriteLine("Enter text to append to the file: ");

            text_to_append = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(filepath, true))
            {
                sw.WriteLine(text_to_append);
            }
            Console.WriteLine("Text has been appended to the file!");
            
            Console.WriteLine("\nDisplaying the file: ");
            using (StreamReader sr = new StreamReader(filepath))
            {
                string output;
                while((output = sr.ReadLine()) != null)
                {
                    Console.WriteLine(output);
                }
            }
            Console.ReadLine();
        }
    }
}
