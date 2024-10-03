using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                    result = command.ExecuteScalar()?.ToString();
                }
            }

            return result;
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
        public DataTable GetAvailableLeftovers(long assemblySiteId)
        {
            
            DataTable leftoversTable = new DataTable();  // Таблица для хранения результатов

            using (SqlConnection connection = new SqlConnection(_connect.ConnectionString))
            {
                connection.Open();  // Открываем подключение к базе данных

                // Запрос для получения остатков номенклатуры
                string query = "SELECT * FROM dbo.GetAvailableStock(@AssemblySiteId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AssemblySiteId", assemblySiteId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(leftoversTable);  // Заполняем DataTable результатами
                    }
                }
            }

            return leftoversTable;
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
    }
}
