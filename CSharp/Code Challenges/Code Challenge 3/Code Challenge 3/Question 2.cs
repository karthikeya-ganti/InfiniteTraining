using System;

namespace Code_Challenge_3
{
    //2. Write a class Box that has Length and breadth as its members.Write a function that adds 2 box objects 
    //and stores in the 3rd.Display the 3rd object details. Create a Test class to execute the above.
    class Box
    {
        public int Length { get; set; }
        public int Breadth { get; set; }
        public Box() { }
        public Box(int length, int breadth)
        {
            Length = length;
            Breadth = breadth;
        }
        public static Box operator +(Box box1, Box box2)
        {
            Box temp = new Box();
            temp.Length = box1.Length + box2.Length;
            temp.Breadth = box1.Breadth + box2.Breadth;
            return temp;
        }
        public void DisplayBox(Box box)
        {
            Console.WriteLine($"Length of Box = {box.Length}, Breadth of Box = {box.Breadth}");
        }
    }

    class Test
    {
        public static int InputValidation(string ask)
        {
            int input;
            while (true)
            {
                Console.Write(ask);
                string inputs = Console.ReadLine();
                if(int.TryParse(inputs, out input) && input >= 0)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Negative number entered! Enter again!");
                }
            }
        }
        static void Main()
        {
            Console.WriteLine("----- Question 2 -----");
            Console.WriteLine("Enter details for Box 1: ");
            int length1, breadth1;
            length1 = InputValidation("Enter Length of Box 1: ");
            breadth1 = InputValidation("Enter Breadth of Box 1: ");

            Box box1 = new Box(length1, breadth1);

            Console.WriteLine();

            Console.WriteLine("Enter details for Box 2: ");
            int length2, breadth2;
            length2 = InputValidation("Enter Length of Box 2: ");
            breadth2 = InputValidation("Enter Breadth of Box 2: ");

            Box box2 = new Box(length2, breadth2);

            Box box3 = new Box();

            box3 = box1 + box2;

            Console.WriteLine();

            Console.WriteLine("Details of New Box are: ");
            box3.DisplayBox(box3);
            
            Console.ReadLine();
        }
    }
}
