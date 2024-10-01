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
    }
}
