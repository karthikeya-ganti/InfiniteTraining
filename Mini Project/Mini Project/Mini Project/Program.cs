using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Mini_Project
{
    class Program
    {
        public static string connect = "Data Source=ICS-LT-5C40D64\\SQLEXPRESS;Initial Catalog=MiniProject;" +
                "user id = sa; password = Infinite@1806657;";
        public static SqlConnection con = new SqlConnection(connect);
        public static SqlCommand cmd;

        static void Main(string[] args)
        {
            bool looping = true;
            while (looping)
            {
                Console.WriteLine("\t\t\t\t\tWelcome to Railway Reservation!!");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.Write("1. Login as Admin\t");
                Console.Write("2. Login as Customer\t");
                Console.Write("3. Exit\t\n");
                Console.Write("Enter your option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nAdmin Login:");
                        Console.Write("Enter username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();
                        Console.Write("Enter role: ");
                        string role = Console.ReadLine();
                        if(AuthenticateUser(username, password, role) && role == "admin")
                        {
                            Console.WriteLine("\nAuthenticated!!\n");
                            AdminMenu();
                        }
                        else
                        {
                            Console.WriteLine("Wrong Credentials or Role Try Again!\n");
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nCustomer Login:");
                        Console.Write("Enter username: ");
                        string username1 = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string password1 = Console.ReadLine();
                        Console.Write("Enter role: ");
                        string role1 = Console.ReadLine();
                        if (AuthenticateUser(username1, password1, role1) && role1 == "customer")
                        {
                            Console.WriteLine("\nAuthenticated!!\n");
                            CustomerMenu();
                        }
                        else
                        {
                            Console.WriteLine("Wrong Credentials or Role Try Again!\n");
                        }
                        break;
                    case 3:
                        looping = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option entered!! Please Try Again!\n");
                        break;
                }
            }
            Console.ReadKey();
        }

        static bool AuthenticateUser(string username, string password, string role)
        { 
            cmd = new SqlCommand("sp_AuthenticateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@role", role);

            SqlParameter output = new SqlParameter("@authentication", SqlDbType.Bit);
            output.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(output);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return Convert.ToBoolean(output.Value);
        }

        static void AdminMenu()
        {
            bool admin = true;
            while (admin)
            {
                Console.WriteLine("\nAdmin Menu");
                Console.WriteLine("1. Register User");
                Console.WriteLine("2. View Trains");
                Console.WriteLine("3. View Bookings");
                Console.WriteLine("4. View Cancellations");
                Console.WriteLine("5. Add Train");
                Console.WriteLine("6. Delete Train");
                Console.WriteLine("7. Logout");
                Console.Write("Enter your option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        RegisterUser();
                        break;

                    case 2:
                        ViewTrains();
                        break;

                    case 3:
                        ViewBookings();
                        break;

                    case 4:
                        ViewCancellations();
                        break;

                    case 5:
                        AddTrain();
                        break;

                    case 6:
                        DeleteTrain();
                        break;

                    case 7:
                        admin = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Option Entered! Please Try Again!!\n");
                        break;
                }
            }
        }

        static void CustomerMenu()
        {
            bool customer = true;
            while (customer)
            {
                Console.WriteLine("\nCustomer Menu");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. View Trains");
                Console.WriteLine("3. Check Seats Available");
                Console.WriteLine("4. Book Tickets");
                Console.WriteLine("5. Cancel Tickets");
                Console.WriteLine("6. Logout");
                Console.Write("\nEnter your option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddCustomer();
                        break;

                    case 2:
                        ViewTrains();
                        break;

                    case 3:
                        CheckSeatsAvailable();
                        break;

                    case 4:
                        BookTickets();
                        break;

                    case 5:
                        CancelTickets();
                        break;

                    case 6:
                        customer = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Option Entered! Please Try Again!!\n");
                        break;
                }
            }
        }

        static void RegisterUser()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Role (admin/customer): ");
            string role = Console.ReadLine();

            cmd = new SqlCommand("sp_RegisterUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@role", role);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("\nUser registered successfully!\n");
        }

        static void ViewTrains()
        {
            Console.WriteLine();
            cmd = new SqlCommand("sp_ViewTrains", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr["train_name"]} from {dr["from"]} to {dr["to"]}, {dr["class_name"]}, Seats: {dr["seats_available"]}, Price: {dr["price"]}, Status: {dr["status"]}");
            }
            dr.Close();
            con.Close();
        }

        static void ViewBookings()
        {
            Console.WriteLine();
            cmd = new SqlCommand("sp_ViewAllBookings", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"Booking ID: {dr["bid"]}, Customer Name: {dr["customer_name"]},  booked {dr["train_no"]} - {dr["train_name"]} - {dr["class_name"]}, "
                                            + $"Travel Date: {dr["travel_date"]}, Seats Booked: {dr["seats_booked"]}, Total Cost: {dr["total_cost"]}");
            }
            dr.Close();
            con.Close();
        }

        static void ViewCancellations()
        {
            Console.WriteLine();
            cmd = new SqlCommand("sp_ViewAllCancellations", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"Cancel ID: {dr["cancel_id"]}, Booking ID: {dr["bid"]}, Customer Name: {dr["customer_name"]},  booked {dr["train_no"]} - {dr["train_name"]} - {dr["class_name"]}, "
                                            + $"Booking Date: {dr["booking_date"]}, Cancel Date: {dr["cancel_date"]}, Refund Amount: {dr["refund_amount"]}");
            }
            dr.Close();
            con.Close();
        }

        static void AddTrain()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Train Details: ");
            Console.Write("Train No: ");
            int train_no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Train Name: ");
            string train_name = Console.ReadLine();
            Console.Write("From: ");
            string from = Console.ReadLine();
            Console.Write("To: ");
            string to = Console.ReadLine();
            Console.Write("Class ID (1. First AC, 2. Second AC, 3. Sleeper, 4. General): ");
            int class_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Seats Available: ");
            int seats_available = Convert.ToInt32(Console.ReadLine());
            Console.Write("Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            cmd = new SqlCommand("sp_AddTrain", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@train_no", train_no);
            cmd.Parameters.AddWithValue("@train_name", train_name);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
            cmd.Parameters.AddWithValue("@class_id", class_id);
            cmd.Parameters.AddWithValue("@seats_available", seats_available);
            cmd.Parameters.AddWithValue("@price", price);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr["message"].ToString());
            }
            dr.Close();
            con.Close();
        }

        static void DeleteTrain()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Train To Delete: ");
            Console.Write("Train No: ");
            int trainno = Convert.ToInt32(Console.ReadLine());

            cmd = new SqlCommand("sp_DeleteTrain", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@train_no", trainno);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr["message"].ToString());
            }
            dr.Close();
            con.Close();
        }

        static void AddCustomer()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            cmd = new SqlCommand("sp_AddCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@age", age);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("Customer added Successfully!");
        }

        static void CheckSeatsAvailable()
        {
            Console.Write("Train No: ");
            int train_no = int.Parse(Console.ReadLine());
            Console.Write("Class ID (1. First AC, 2. Second AC, 3. Sleeper, 4. General): ");
            int class_id = int.Parse(Console.ReadLine());

            cmd = new SqlCommand("sp_CheckSeatsAvailable", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@train_no", train_no);
            cmd.Parameters.AddWithValue("@class_id", class_id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"Seats Available: {dr["seats_available"]}");
            }
            dr.Close();
            con.Close();
        }

        static void BookTickets()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Details to Book Tickets: ");
            Console.Write("Customer Name: ");
            string customer_name = Console.ReadLine();
            Console.Write("Train No: ");
            int train_no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Class ID: ");
            int class_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Travel Date (yyyy-mm-dd): ");
            DateTime travel_date = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Seats to Book: ");
            int seats_booked = Convert.ToInt32(Console.ReadLine());

            cmd = new SqlCommand("sp_BookTickets", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@customer_name", customer_name);
            cmd.Parameters.AddWithValue("@train_no", train_no);
            cmd.Parameters.AddWithValue("@class_id", class_id);
            cmd.Parameters.AddWithValue("@travel_date", travel_date);
            cmd.Parameters.AddWithValue("@seats_booked", seats_booked);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr["Message"].ToString());
                Console.WriteLine($"Booking Id is: {dr["bookid"]}");
            }
            dr.Close();
            con.Close();
        }

        static void CancelTickets()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Cancel Details");
            Console.Write("Customer ID: ");
            int customer_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Booking ID: ");
            int bid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Seats to Cancel: ");
            int seats = Convert.ToInt32(Console.ReadLine());

            cmd = new SqlCommand("sp_CancelTickets", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@custid", customer_id);
            cmd.Parameters.AddWithValue("@bookid", bid);
            cmd.Parameters.AddWithValue("@seats_cancelled", seats);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr["Message"].ToString());
            }
            dr.Close();
            con.Close();
        }
    }
}
