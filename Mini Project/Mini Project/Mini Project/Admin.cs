using System;
using System.Data;
using System.Data.SqlClient;

namespace Mini_Project
{
    class Admin : RailwayReservation
    {
        internal void RegisterUser()
        {
            try
            {
                Console.WriteLine();
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

                Console.WriteLine("\nUser registered successfully!\n");
            }
            catch (SqlException se)
            {
                Console.WriteLine();
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        internal void ViewTrains()
        {
            try
            {
                Console.WriteLine();
                cmd = new SqlCommand("sp_ViewTrains", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("Trains Data: ");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["train_no"]} - {dr["train_name"]} from {dr["from"]} to {dr["to"]}, {dr["class_name"]}, Seats: {dr["seats_available"]}, Price: {dr["price"]}, Status: {dr["status"]}");
                }
                Console.WriteLine();
                dr.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine();
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        internal void ViewBookings()
        {
            try
            {
                Console.WriteLine();
                cmd = new SqlCommand("sp_ViewAllBookings", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"Booking ID: {dr["bid"]}, Customer Name: {dr["customer_name"]},  booked {dr["train_no"]} - {dr["train_name"]} - {dr["class_name"]}, "
                                                + $"Travel Date: {dr["travel_date"]}, Seats Booked: {dr["seats_booked"]}, Total Cost: {dr["total_cost"]}, Booking Status: {dr["BookingStatus"]}");
                }
                Console.WriteLine();
                dr.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine();
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        internal void ViewCancellations()
        {
            try
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
                Console.WriteLine();
                dr.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine();
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        internal void AddTrain()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter Train Details: ");
                Console.Write("Train No: ");
                int train_no; while (!int.TryParse(Console.ReadLine(), out train_no)) ;
                Console.Write("Train Name: ");
                string train_name = Console.ReadLine();
                Console.Write("From: ");
                string from = Console.ReadLine();
                Console.Write("To: ");
                string to = Console.ReadLine();
                Console.Write("Class ID (1. First AC, 2. Second AC, 3. Sleeper, 4. General): ");
                int class_id; while (!int.TryParse(Console.ReadLine(), out class_id)) ;
                Console.Write("Seats Available: ");
                int seats_available; while (!int.TryParse(Console.ReadLine(), out seats_available)) ;
                Console.Write("Price: ");
                decimal price; while (!decimal.TryParse(Console.ReadLine(), out price)) ;

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
                Console.WriteLine();
                dr.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine();
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        internal void ModifyTrain()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Modify Train Details:");
                Console.Write("Enter Train No: ");
                int train_no; while (!int.TryParse(Console.ReadLine(), out train_no)) ;

                Console.WriteLine("\nChoose field to modify:");
                Console.WriteLine("1. Train Name");
                Console.WriteLine("2. From Station");
                Console.WriteLine("3. To Station");
                Console.WriteLine("4. Class");
                Console.WriteLine("5. Seats Available");
                Console.WriteLine("6. Price");
                Console.WriteLine("7. Reactivate Train");
                Console.Write("Enter your choice (1-7): ");
                int input; while (!int.TryParse(Console.ReadLine(), out input)) ;

                cmd = new SqlCommand("sp_ModifyTrain", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@train_no", train_no);
                cmd.Parameters.AddWithValue("@input", input);

                if (input >= 1 && input <= 3)
                {
                    Console.Write("\nEnter new value: ");
                    string new_value = Console.ReadLine();
                    cmd.Parameters.AddWithValue("@new_value", new_value);
                }
                else if (input == 4)
                {
                    Console.Write("\nEnter current Class ID (1. First AC, 2. Second AC, 3. Sleeper, 4. General): ");
                    int class_id; while (!int.TryParse(Console.ReadLine(), out class_id)) ;
                    Console.Write("\nEnter new Class ID (1. First AC, 2. Second AC, 3. Sleeper, 4. General): ");
                    int new_class_id; while (!int.TryParse(Console.ReadLine(), out new_class_id)) ;

                    cmd.Parameters.AddWithValue("@class_id", class_id);
                    cmd.Parameters.AddWithValue("@new_int_value", new_class_id);
                }
                else if (input == 5)
                {
                    Console.Write("\nEnter Class ID (1. First AC, 2. Second AC, 3. Sleeper, 4. General): ");
                    int class_id; while (!int.TryParse(Console.ReadLine(), out class_id)) ;
                    Console.Write("\nEnter new Seats Available: ");
                    int seats_available; while (!int.TryParse(Console.ReadLine(), out seats_available)) ;

                    cmd.Parameters.AddWithValue("@class_id", class_id);
                    cmd.Parameters.AddWithValue("@new_int_value", seats_available);
                }
                else if (input == 6)
                {
                    Console.Write("\nEnter Class ID (1. First AC, 2. Second AC, 3. Sleeper, 4. General): ");
                    int class_id; while (!int.TryParse(Console.ReadLine(), out class_id)) ;
                    Console.Write("\nEnter new Price: ");
                    decimal price; while (!decimal.TryParse(Console.ReadLine(), out price)) ;

                    cmd.Parameters.AddWithValue("@class_id", class_id);
                    cmd.Parameters.AddWithValue("@new_decimal_value", price);
                }

                else if (input == 7)
                {
                    Console.WriteLine("\nMarking the Train as Active.....");
                }

                else
                {
                    Console.WriteLine("Invalid input.");
                    return;
                }

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr["message"].ToString());
                }
                Console.WriteLine();
                dr.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine();
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }


        internal void DeleteTrain()
        {
            try
            {
                Console.WriteLine();
                Console.Write("Enter Train No to delete: ");
                int train_no;
                while (!int.TryParse(Console.ReadLine(), out train_no)) ;

                // Check if train has active bookings
                bool hasBookings = false;
                cmd = new SqlCommand("select count(*) from bookings where train_no = @train_no and is_cancelled = 0", con);
                cmd.Parameters.AddWithValue("@train_no", train_no);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();

                if (count > 0)
                {
                    Console.WriteLine("\nTrain has active bookings. Choose an option:");
                    Console.WriteLine("1. Cancel all bookings and delete the train");
                    Console.WriteLine("2. Abort deletion");
                    Console.Write("Enter your choice (1 or 2): ");
                    int option;
                    while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2)) ;

                    cmd = new SqlCommand("sp_DeleteTrain", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@train_no", train_no);
                    cmd.Parameters.AddWithValue("@option", option);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["message"].ToString());
                    }
                    dr.Close();
                }
                else
                {
                    // No bookings, deactivate silently
                    cmd = new SqlCommand("sp_DeleteTrain", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@train_no", train_no);
                    cmd.Parameters.AddWithValue("@option", 0); // 0 means silent deactivate

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Train had no bookings and was deactivated successfully.");
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine();
                Console.WriteLine(se.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

    }
}