using System.Data.SqlClient;
using System.Configuration;

namespace ElectricityDB
{
    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            string connect = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
            return new SqlConnection(connect);
        }
    }
}
