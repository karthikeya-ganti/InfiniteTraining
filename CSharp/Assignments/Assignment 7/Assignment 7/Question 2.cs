using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    //2. Write a query that returns words starting with letter 'a' and ending with letter 'm'.
    class Question_2
    {
        static void Main()
        {
            int wordCount;
            Console.Write("Enter no of words: ");
            wordCount = Convert.ToInt32(Console.ReadLine());
            string[] input = new string[wordCount];
            for(int i = 0; i < wordCount; i++)
            {
                Console.Write("Enter Word {0}: ", i + 1);
                input[i] = Console.ReadLine().ToLower();
            }
            string firstLetter, lastLetter;
            Console.Write("Enter First letter: ");
            firstLetter = Console.ReadLine().ToLower();
            Console.Write("Enter Last letter: ");
            lastLetter = Console.ReadLine().ToLower();

            IEnumerable<string> filteredOutput = from word in input
                                                where word.EndsWith(lastLetter) && word.StartsWith(firstLetter)
                                                select word;
            Console.WriteLine("\nAfter Performing Query...");
            Console.WriteLine($"\nThe words which starts with {firstLetter} and ends with {lastLetter} are: ");
            foreach(var v in filteredOutput)
            {
                Console.WriteLine(v);
            }

            Console.ReadKey();
        }
    }
}
