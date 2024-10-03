using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Test.October.DataAccess
{
    public class DbConnect
    {
        public string ConnectionString { get; set; }
        public DbConnect()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
        }

        public async  void ConnectToDbAsync()
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
