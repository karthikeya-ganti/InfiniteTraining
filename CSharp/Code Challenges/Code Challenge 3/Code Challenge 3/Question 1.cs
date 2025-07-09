using System;
using System.Collections.Generic;

namespace Code_Challenge_3
{
    //1. Write a program to find the Sum and the Average points scored by the teams in the IPL.
    //   Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches) that takes 
    //   no.of matches as input and accepts that many scores from the user.The function should then 
    //   return the Count of Matches, Average and Sum of the scores
    
    class CricketTeam
    {
        public (int count_of_matches, double average_of_matches, int sum_of_matches) PointsCalculation(int no_of_matches)
        {
            if(no_of_matches == 0)
            {
                return (0, 0, 0);
            }
            List<int> scores_of_team = new List<int>();
            Console.WriteLine("Enter the scores: ");
            int sum_of_scores = 0;
            double average_of_scores;
            for (int i = 0; i < no_of_matches; i++)
            {
                int score;
                while (true)
                {
                    Console.Write("Enter Score of Match {0}: ", i + 1);
                    string points = Console.ReadLine();
                    if(int.TryParse(points,out score) && score >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Score Entered!! Enter only positive number!");
                    }
                }
                scores_of_team.Add(score);
                sum_of_scores += score;
            }
            average_of_scores = sum_of_scores / no_of_matches;
            return (no_of_matches, average_of_scores, sum_of_scores);
        }
    }
    class Question_1
    {
        static void Main()
        {
            Console.WriteLine("----- Question 1 -----");
            CricketTeam iplteam = new CricketTeam();
            string ipl;
            Console.Write("Enter team name: ");
            ipl = Console.ReadLine();
            int no_of_matches;
            while (true)
            {
                Console.Write($"Enter no of matches played by the {ipl} team: ");
                string count = Console.ReadLine();
                if (int.TryParse(count, out no_of_matches) && no_of_matches >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("No. of matches cannot be negative! Enter a valid input!");
                }
            }
            var output = iplteam.PointsCalculation(no_of_matches);
            Console.WriteLine();
            Console.WriteLine($"Total Matches played by the {ipl} team are: {output.count_of_matches}");
            Console.WriteLine($"Sum of the scores of {ipl} team are: {output.sum_of_matches}");
            Console.WriteLine($"Average score of the {ipl} team is: {output.average_of_matches}");
            Console.ReadKey();
        }
    }
}
