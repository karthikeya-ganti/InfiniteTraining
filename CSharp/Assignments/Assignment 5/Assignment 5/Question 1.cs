using System;

namespace Assignment_5
{
    //Question 1
    //Exception Handling :  
    //1.
    //•	You have a class which has methods for transaction for a banking system. (created earlier)
    //•	Define your own methods for deposit money, withdraw money and balance in the account.
    //•	Write your own new application Exception class called InsuffientBalanceException.
    //•	This new Exception will be thrown in case of withdrawal of money from the account where customer doesn’t have sufficient balance.
    //•	Identify and categorize all possible checked and unchecked exception.
    

    //user defined exception
    class InsuffientBalanceException : ApplicationException
    {
        public InsuffientBalanceException(string message) : base(message)
        {
            Console.WriteLine("\n\t\tError \nInsufficient Balance to Withdraw!!");
        }
    }

    //user defined exception
    class NegativeOrZeroDepositException : ApplicationException
    {
        public NegativeOrZeroDepositException(string message): base(message)
        {
            Console.WriteLine("\n\t\tError \nNegative or Zero Amount Entered!!");
        }
    }
    class Accounts
    {
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
                throw new InsuffientBalanceException($"Amount to Withdraw {amount} is less than Balance {Balance}.");
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
            if(amount <= 0)
            {
                throw new NegativeOrZeroDepositException("Cannot Deposit Negative or Zero Rupees.");
            }
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
    class Question_1
    {
        static void Main()
        {
            int accountno = 0;
            string customername;
            string accounttype;
            char transactiontype;
            int amount = 0;

            Console.WriteLine("Enter Account Details: ");
            Console.Write("Enter Account Number: ");
            try
            {
                accountno = Int32.Parse(Console.ReadLine());
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
                            try
                            {
                                amount = Convert.ToInt32(Console.ReadLine());
                            }
                            catch(FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            try
                            {
                                accounts.Credit(amount);
                            }
                            catch(NegativeOrZeroDepositException e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }
                        else if (transactiontype == 'W' || transactiontype == 'w')
                        {
                            Console.Write("Enter Amount to Withdraw: ");
                            amount = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                accounts.Debit(amount);
                            }
                            catch(InsuffientBalanceException e)
                            {
                                Console.WriteLine(e.Message);
                            }
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