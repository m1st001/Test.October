using System.Data;
using System.Data.SqlClient;
using Test.October.DataAccess;

namespace Test.October.Data
{
    public class Logic
    {
        private readonly DbConnect _connect;
        public Logic()
        {
            _connect = new DbConnect();
        }

        public string CheckAssemblyFeasibility(int orderId)
        {
            string result = string.Empty;

            using (SqlConnection connection = new SqlConnection(_connect.ConnectionString))
            {
                connection.Open();
                string query = "SELECT dbo.CheckAssemblyFeasibility(@OrderId) AS FeasibilityResult";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);

                    result = command.ExecuteScalar()?.ToString()!;
                }
            }

            return result!;
        }

        public DataTable GetItemQuantitiesBySite(long assemblySiteId)
        {
            DataTable resultTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connect.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM dbo.GetItemQuantitiesBySite(@AssemblySiteId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AssemblySiteId", assemblySiteId);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(resultTable);  // Заполняем DataTable результатами
                    }
                }
            }

            return resultTable;
        }
        public DataTable GetAssemblyTasks()
        {
            DataTable tasksTable = new DataTable();  // Таблица для хранения результатов

            using (SqlConnection connection = new SqlConnection(_connect.ConnectionString))
            {
                connection.Open();  // Открываем подключение к базе данных

                // Запрос для вызова функции, которая возвращает данные о задачах сборки
                string query = "SELECT * FROM dbo.GetAssemblyTasks()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(tasksTable);  // Заполняем DataTable результатами
                    }
                }
            }

            return tasksTable;
        }

        public DataTable CheckActiveAssembly()
        {
            DataTable activeAssemblyTable = new DataTable();

            using(SqlConnection connection = new SqlConnection(_connect.ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.GetActiveAssemblySites()";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(activeAssemblyTable);
                    }
                }
            }

            return activeAssemblyTable;
        }

        public DataTable GetAvailableInventory()
        {
            DataTable activeAssemblyTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connect.ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.GetAvailableInventory()";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(activeAssemblyTable);
                    }
                }
            }

            return activeAssemblyTable;
        }
    }
}
