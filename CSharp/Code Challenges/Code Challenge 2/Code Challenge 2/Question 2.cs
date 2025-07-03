using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_2
{
    //Question 2
    //2. Create a Class called Products with Productid, Product Name, Price.
    //Accept 10 Products, sort them based on the price, and display the sorted Products
    class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

        public Products(int id, string name, int price)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
        }

        public void Display()
        {
            Console.WriteLine($"Product Id = {ProductId} Product Name = {ProductName} Product Price = {ProductPrice}");
        }
    }
    class Question_2
    {
        static void Main()
        {
            Console.WriteLine("----- Question 2 -----");
            int productcount;
            Console.Write("Enter No. of Products: ");
            productcount = Convert.ToInt32(Console.ReadLine());
            
            Products[] productList = new Products[productcount];
            
            for (int i = 0; i < productcount; i++)
            {
                int id;
                string name;
                int price;
                Console.WriteLine($"Enter Product {i + 1} details: ");
                
                Console.Write("Enter the Product Id: ");
                id = Convert.ToInt32(Console.ReadLine());
                
                Console.Write("Enter the Product Name: ");
                name = Console.ReadLine();
                
                Console.Write("Enter the Product Price: ");
                price = Convert.ToInt32(Console.ReadLine());
                
                productList[i] = new Products(id, name, price);
                Console.WriteLine();
            }

            Console.WriteLine("Products Before Sorting: \n");

            for (int i = 0; i < productcount; i++)
            {
                productList[i].Display();
            }

            Array.Sort(productList, (p1, p2) => p1.ProductPrice - p2.ProductPrice);

            Console.WriteLine("Product list After Sorting: \n");
            
            for (int i = 0; i < productcount; i++)
            {
                productList[i].Display();
            }

            Console.ReadKey();
        }
    }
}
