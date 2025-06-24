using System;

namespace Assignment_3
{
    class Accounts
    {
         //  1. Create a class called Accounts which has data members/fields like Account no, Customer name, Account type, Transaction type(d/w), amount, balance
         //  D->Deposit
         //  W->Withdrawal
         //  -write a function that updates the balance depending upon the transaction type
         //  -If transaction type is deposit call the function credit by passing the amount to be deposited and update the balance
         //   function Credit(int amount)
	     // -If transaction type is withdraw call the function debit by passing the amount to be withdrawn and update the balance
         //   Debit(int amt) function 
         //   -Pass the other information like Account no	, customer name, acc type through constructor
         //   -write and call the show data method to display the values.



        int AccountNo;
        string CustomerName;
        string AccountType;
        int Balance;
        // creating accounts constructor to pass values
        public Accounts(int accountno, string customername, string accounttype)
        {
            AccountNo = accountno;
            CustomerName = customername;
            AccountType = accounttype;
            Balance = 0;
        }
        
        //debit method to withdraw
        public void Debit(int amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient Balance!!");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine("The updated balance = {0}", Balance);
            }
        }
        //credit method to deposit
        public void Credit(int amount)
        {
            Balance += amount;
            Console.WriteLine("The updated balance = {0}", Balance);
        }
        //displaying customer account details
        public void Display()
        {
            Console.WriteLine("-------------- Account Details -------------------");
            Console.WriteLine("Account Number = {0}", AccountNo);
            Console.WriteLine("Customer Name = {0}", CustomerName);
            Console.WriteLine("Account Type = {0}", AccountType);
            Console.WriteLine("Balance = {0}", Balance);
        }
    }
    class Inheritance1
    {
        static void Main()
        {
            int accountno;
            string customername;
            string accounttype;
            char transactiontype;
            int amount;

            Console.WriteLine("Enter Account Details: ");
            Console.Write("Enter Account Number: ");
            accountno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            customername = Console.ReadLine();
            Console.Write("Enter Account Type: ");
            accounttype = Console.ReadLine();
     
            Accounts accounts = new Accounts(accountno, customername, accounttype);
            //interactive session of updation and diplaying 
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("\nEnter Option: ");
                Console.WriteLine("U - Update Balance");
                Console.WriteLine("S - Display Details");
                Console.WriteLine("E - Exit");
                char option = Convert.ToChar(Console.ReadLine());
                switch (option)
                {
                    case 'U':
                    case 'u':
                        Console.Write("Enter Transaction Type (D - Deposit, W - Withdraw): ");
                        transactiontype = Convert.ToChar(Console.ReadLine());
                        if (transactiontype == 'D' || transactiontype == 'd')
                        {
                            Console.Write("Enter Amount to Deposit: ");
                            amount = Convert.ToInt32(Console.ReadLine());
                            accounts.Credit(amount);
                        }
                        else if (transactiontype == 'W' || transactiontype == 'w')
                        {
                            Console.Write("Enter Amount to Withdraw: ");
                            amount = Convert.ToInt32(Console.ReadLine());
                            accounts.Debit(amount);
                        }
                        break;
                    case 'S':
                    case 's':
                        accounts.Display();
                        break;
                    case 'E':
                    case 'e':
                        loop = false;                       
                        break;
                    default:
                        Console.WriteLine("Please Enter the Option again.");
                        break;
                }
            }
            
            Console.ReadKey();
        }
    }
}
