using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ElectricityDB;

namespace Electricity_Prj
{
    public class ElectricityBoard
    {
        DBHandler db = new DBHandler();
        public void AddBill(ElectricityBill ebill)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("insert into ElectricityBill (consumer_number, consumer_name, units_consumed, bill_amount) values (@num, @name, @units, @amount)", con);
                cmd.Parameters.AddWithValue("@num", ebill.ConsumerNumber);
                cmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
                cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                cmd.Parameters.AddWithValue("@amount", ebill.BillAmount);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double billamount = 0;
            if(units <= 100)
            {
                billamount = 0;
            }
            else if (units <= 300)
            {
                billamount = (units - 100) * 1.50;

            }
            else if (units <= 600)
            {
                billamount = (200 * 1.50) + (units - 300) * 3.50;
            }
            else if (units <= 1000)
            {
                billamount = (200 * 1.50) + (300 * 3.50) + (units - 600) * 5.50;
            }
            else
            {
                billamount = (200 * 1.50) + (300 * 3.50) + (400 * 5.50) + (units - 1000) * 7.50;
            }
            ebill.BillAmount = billamount;
        }

        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            List<ElectricityBill> bills = new List<ElectricityBill>();
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand($"select top {num} consumer_number, consumer_name, units_consumed, bill_amount from ElectricityBill order by consumer_number desc", con);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var bill = new ElectricityBill
                        {
                            ConsumerNumber = dr["consumer_number"].ToString(),
                            ConsumerName = dr["consumer_name"].ToString(),
                            UnitsConsumed = Convert.ToInt32(dr["units_consumed"]),
                            BillAmount = Convert.ToDouble(dr["bill_amount"])
                        };
                        bills.Add(bill);
                    }
                }
            }
            return bills;
        }
    }
}