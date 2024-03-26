using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.DataAccess
{
    internal class ConnectDB
    {
        private readonly string _connectionString;

        public ConnectDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool CheckUserCredentials(string login, string password)
        {
            bool result = false;

            using var con = new NpgsqlConnection(_connectionString);
            try
            {
                con.Open();
                Console.WriteLine("Подключение к базе данных установлено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при подключении к базе данных: " + ex.Message);
            }
            return result;
        }
    }
}
