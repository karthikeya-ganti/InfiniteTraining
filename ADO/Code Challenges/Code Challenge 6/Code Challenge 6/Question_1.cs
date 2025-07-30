using System;
using System.Data;
using System.Data.SqlClient;


namespace Code_Challenge_6
{
    class Question_1
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static SqlConnection getConnection()
        {
            string connect = "Data Source=ICS-LT-5C40D64\\SQLEXPRESS;Initial Catalog=CodeChallenges;" +
                "user id = sa; password = Infinite@1806657;";
            con = new SqlConnection(connect);
            con.Open();
            return con;
        }
        static void SelectData()
        {
            Console.WriteLine("\nEmployee_Details Table Contents:");
            try
            {
                con = getConnection();
                cmd = new SqlCommand("select * from Employee_Details", con);

                dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    Console.WriteLine($"Empid      : {dr["Empid"]}");
                    Console.WriteLine($"Name       : {dr["Name"]}");
                    Console.WriteLine($"Salary     : {dr["Salary"]}");
                    Console.WriteLine($"Gender     : {dr["Gender"]}");
                    Console.WriteLine($"NetSalary  : {dr["NetSalary"]}");
                    Console.WriteLine();
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
        }
        static void InsertData()
        {
            try
            {
                con = getConnection();
                Console.WriteLine("Please Enter Employee Details: ");
                Console.Write("Enter Name: ");
                string ename = Console.ReadLine();
                Console.Write("Enter Salary: ");
                int esalary = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Gender: ");
                string egender = Console.ReadLine();

                cmd = new SqlCommand("sp_InsertRecords", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", ename);
                cmd.Parameters.AddWithValue("@sal", esalary);
                cmd.Parameters.AddWithValue("@gender", egender);

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Console.WriteLine("\nThe inserted data is:");
                    while (dr.Read())
                    {
                        Console.WriteLine("Employee ID    : " + dr["Empid"]);
                        Console.WriteLine("Employee Name  : " + dr["Name"]);
                        Console.WriteLine("Employee Gender: " + dr["Gender"]);
                        Console.WriteLine("Employee Salary: " + dr["Salary"]);
                        Console.WriteLine("Net Salary     : " + dr["NetSalary"]);
                    }
                }
                dr.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
        }
        static void Main()
        {
            InsertData();
            SelectData();
            Console.ReadKey();
        }
    }
}
