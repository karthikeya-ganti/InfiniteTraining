using System;
using System.Data;
using System.Data.SqlClient;

namespace Code_Challenge_6
{
    class Question_2
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static SqlConnection getConnection()
        {
            string connect = "Data Source=ICS-LT-5C40D64\\SQLEXPRESS;Initial Catalog=CodeChallenges;" +
                             "user id=sa; password = Infinite@1806657;";
            con = new SqlConnection(connect);
            con.Open();
            return con;
        }

        static void UpdateSalary()
        {
            try
            {
                con = getConnection();

                Console.Write("Enter Employee ID to update salary: ");
                int eid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n----- Before -----");
                cmd = new SqlCommand("select * from employee where id = @eid", con);
                cmd.Parameters.AddWithValue("@eid", eid);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("Employee ID: " + dr["id"]);
                        Console.WriteLine("Employee Name: " + dr["name"]);
                        Console.WriteLine("Employee Age: " + dr["age"]);
                        Console.WriteLine("Employee Address: " + dr["address"]);
                        Console.WriteLine("Employee Salary: " + dr["salary"]);
                    }
                }
                dr.Close();

                cmd = new SqlCommand("sp_UpdateSalary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", eid);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("select * from employee where id = @eid", con);
                cmd.Parameters.AddWithValue("@eid", eid);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Console.WriteLine("\nThe updated data is:");
                    while (dr.Read())
                    {
                        Console.WriteLine("Employee ID: " + dr["id"]);
                        Console.WriteLine("Employee Name: " + dr["name"]);
                        Console.WriteLine("Employee Age: " + dr["age"]);
                        Console.WriteLine("Employee Address: " + dr["address"]);
                        Console.WriteLine("Employee Salary: " + dr["salary"]);
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
            UpdateSalary();
            Console.ReadKey();
        }
    }
}
