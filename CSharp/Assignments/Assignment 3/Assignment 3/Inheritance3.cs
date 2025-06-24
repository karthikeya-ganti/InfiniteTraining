using System;

namespace Assignment_3
{
    //3. Create a class called Saledetails which has data members like Salesno,  Productno,  Price, dateofsale, Qty, TotalAmount
    //- Create a method called Sales() that takes qty, Price details of the object and updates the TotalAmount as  Qty* Price
    //- Pass the other information like SalesNo, Productno, Price, Qty and Dateof sale through constructor
    //- call the show data method to display the values without an object.

    class SaleDetails
    {
        static int SalesNo;
        static int ProductNo;
        static int Price;
        static DateTime DateofSale;
        static int Quantity;
        static int TotalAmount;

        //Passing values to constructor
        public SaleDetails(int salesno,int productno, int price, DateTime dateofsale,int quantity)
        {
            SalesNo = salesno;
            ProductNo = productno;
            Price = price;
            DateofSale = dateofsale;
            Quantity = quantity;
        }
        //Calculating Sales Method
        public static int Sales(int quantity,int price)
        {
            TotalAmount = quantity * price;
            return TotalAmount;
        }
        //method to display data
        public static void ShowData()
        {
            Console.WriteLine("\n----- Details of the Sale: -----");
            Console.WriteLine($"Sales Number = {SalesNo}");
            Console.WriteLine($"Product Number = {ProductNo}");
            Console.WriteLine($"Price of the Product = {Price}");
            Console.WriteLine($"Date of the Sale = {DateofSale}");
            Console.WriteLine($"Quantity = {Quantity}");
            Console.WriteLine($"Total Amount = {Sales(Quantity, Price)}");
        }
    }
    class Inheritance3
    {
        static void Main()
        {
            int salesno;
            int productno;
            int price;
            DateTime dateofsale;
            int quantity;

            //taking inputs from user
            Console.Write("Enter Sales Number: ");
            salesno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Product Number: ");
            productno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Price: ");
            price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Date of Sale: ");
            dateofsale = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            quantity = Convert.ToInt32(Console.ReadLine());

            //creating object to pass values via constructor
            SaleDetails saledetails = new SaleDetails(salesno, productno, price, dateofsale, quantity);
         
            //displaying data without object with calling function
            SaleDetails.ShowData();

            Console.ReadKey();
        }
    }
}
