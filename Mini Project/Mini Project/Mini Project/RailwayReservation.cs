using System;
using System.Data;
using System.Data.SqlClient;

namespace Mini_Project
{
    public class RailwayReservation
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
                int option; while (!int.TryParse(Console.ReadLine(), out option)) ;

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
                            Console.WriteLine($"Welcome, {username}");
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
                            Console.WriteLine($"Welcome, {username1}");
                            CustomerMenu();
                        }
                        else
                        {
                            Console.WriteLine("Wrong Credentials or Role Try Again!\n");
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nThank you! Please Visit Again!!");
                        looping = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option entered!! Please Try Again!\n");
                        break;
                }
            }
            Console.ReadKey();
        }

        public static bool AuthenticateUser(string username, string password, string role)
        {
            try
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

                return Convert.ToBoolean(output.Value);
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return false;
        }

        static void AdminMenu()
        {
            Admin admin = new Admin();
            bool login = true;
            while (login)
            {
                Console.WriteLine("\nAdmin Menu");
                Console.WriteLine("1. Register User");
                Console.WriteLine("2. View Trains");
                Console.WriteLine("3. View Bookings");
                Console.WriteLine("4. View Cancellations");
                Console.WriteLine("5. Add Train or Add Class");
                Console.WriteLine("6. Modify Train Details");
                Console.WriteLine("7. Delete Train");
                Console.WriteLine("8. Logout");
                Console.Write("Enter your option: ");
                int option; while (!int.TryParse(Console.ReadLine(), out option)) ;

                switch (option)
                {
                    case 1:
                        admin.RegisterUser();
                        break;

                    case 2:
                        admin.ViewTrains();
                        break;

                    case 3:
                        admin.ViewBookings();
                        break;

                    case 4:
                        admin.ViewCancellations();
                        break;

                    case 5:
                        admin.AddTrain();
                        break;

                    case 6:
                        admin.ModifyTrain();
                        break;

                    case 7:
                        admin.DeleteTrain();
                        break;

                    case 8:
                        Console.WriteLine("Logout Successful!!\nPlease Visit Again!");
                        login = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Option Entered! Please Try Again!!\n");
                        break;
                }
            }
        }

        static void CustomerMenu()
        {
            bool login = true;
            while (login)
            {
                Customer customer = new Customer();
                Console.WriteLine("\nCustomer Menu");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. View Trains");
                Console.WriteLine("3. Check Seats Available");
                Console.WriteLine("4. Book Tickets");
                Console.WriteLine("5. Cancel Tickets");
                Console.WriteLine("6. View Customer Bookings");
                Console.WriteLine("7. Logout");
                Console.Write("\nEnter your option: ");
                int option; while (!int.TryParse(Console.ReadLine(), out option)) ;

                switch (option)
                {
                    case 1:
                        customer.AddCustomer();
                        break;

                    case 2:
                        customer.ViewTrains();
                        break;

                    case 3:
                        customer.CheckSeatsAvailable();
                        break;

                    case 4:
                        customer.BookTickets();
                        break;

                    case 5:
                        customer.CancelTickets();
                        break;

                    case 6:
                        customer.CustomerBookingHistory();
                        break;

                    case 7:
                        Console.WriteLine("Logout Successful!!\nPlease Visit Again!");
                        login = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Option Entered! Please Try Again!!\n");
                        break;
                }
            }
        }
    }
}