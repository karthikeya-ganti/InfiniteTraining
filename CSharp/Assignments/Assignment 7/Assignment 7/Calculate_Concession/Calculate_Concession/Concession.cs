using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Concession
{
    public class Concession
    {
        public static void CalculateConcession(int age, int fare)
        {
            if (age <= 5)
                Console.WriteLine("Little Champs - Free Ticket");
            else if (age > 60)
                Console.WriteLine($"Senior Citizen Ticket Booked! Fare: " + (fare * 0.7));
            else
                Console.WriteLine($"Ticket Booked! Fare: {fare}");
        }
    }
}
