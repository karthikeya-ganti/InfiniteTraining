using System;
using System.Data;
using System.Data.SqlClient;

namespace Mini_Project
{
    class Customer : RailwayReservation
    {
        internal void AddCustomer()
        {
            try
            {
                Console.WriteLine();
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
                int age; while (!int.TryParse(Console.ReadLine(), out age)) ;

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

                Console.WriteLine("\nCustomer added Successfully!\n");
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
                cmd = new SqlCommand("sp_CustViewTrains", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["train_no"]} - {dr["train_name"]} from {dr["from"]} to {dr["to"]}, {dr["class_name"]}, Seats: {dr["seats_available"]}, Price: {dr["price"]}");
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

        internal void CheckSeatsAvailable()
        {
            try
            {
                Console.WriteLine();
                Console.Write("Train No: ");
                int train_no; while (!int.TryParse(Console.ReadLine(), out train_no)) ;
                Console.Write("Class ID (1. First AC, 2. Second AC, 3. Sleeper, 4. General): ");
                int class_id; while (!int.TryParse(Console.ReadLine(), out class_id)) ;

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

        internal void BookTickets()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter Details to Book Tickets: ");
                Console.Write("Customer Name: ");
                string customer_name = Console.ReadLine();
                Console.Write("Train No: ");
                int train_no; while (!int.TryParse(Console.ReadLine(), out train_no)) ;
                Console.Write("Class ID (1. First AC, 2. Second AC, 3. Sleeper, 4. General): ");
                int class_id; while (!int.TryParse(Console.ReadLine(), out class_id)) ;
                Console.Write("Travel Date (yyyy-mm-dd): ");
                DateTime travel_date; while (!DateTime.TryParse(Console.ReadLine(), out travel_date)) ;
                Console.Write("Seats to Book (Maximum 6 per transaction): ");
                int seats_booked; while (!int.TryParse(Console.ReadLine(), out seats_booked)) ;
                object bid = null;

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
                    Console.WriteLine($"Booking Id: {dr["bookid"]}");
                    bid = dr["bookid"];
                }
                dr.Close();
                con.Close();
                CurrentBooking(bid);
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

        internal void CurrentBooking(object bid)
        {
            try
            {
                Console.WriteLine();
                cmd = new SqlCommand("sp_CurrentBooking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bid", bid);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"Booking ID: {dr["bid"]}, Customer Name: {dr["customer_name"]},  booked {dr["train_no"]} - {dr["train_name"]} - {dr["class_name"]}, "
                                                + $"Travel Date: {dr["travel_date"]}, Seats Booked: {dr["seats_booked"]}, Total Cost: {dr["total_cost"]}");
                }
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

        internal void CancelTickets()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter Cancel Details");
                Console.Write("Customer Name: ");
                string customer_name = Console.ReadLine();
                Console.Write("Booking ID: ");
                int bid; while (!int.TryParse(Console.ReadLine(), out bid)) ;
                Console.Write("Seats to Cancel: ");
                int seats; while (!int.TryParse(Console.ReadLine(), out seats)) ;

                cmd = new SqlCommand("sp_CancelTickets", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_name", customer_name);
                cmd.Parameters.AddWithValue("@bookid", bid);
                cmd.Parameters.AddWithValue("@seats_cancelled", seats);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr["Message"].ToString());
                }
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

        internal void CustomerBookingHistory()
        {
            try
            {
                Console.WriteLine();
                Console.Write("Enter Customer Name: ");
                string customer_name = Console.ReadLine();

                cmd = new SqlCommand("sp_ViewCustomerBookings", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("customer_name", customer_name);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"Booking ID: {dr["bid"]}, Customer Name: {dr["customer_name"]},  booked {dr["train_no"]} - {dr["train_name"]} - {dr["class_name"]}, "
                                                + $"Travel Date: {dr["travel_date"]}, Seats Booked: {dr["seats_booked"]}, Total Cost: {dr["total_cost"]}");
                }
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
    }
}