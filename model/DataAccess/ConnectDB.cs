using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.DataAccess
{
    public class ConnectDB
    {
        private readonly string _connectionString;

        public ConnectDB()
        {
            _connectionString = "Host=26.133.59.159;Username=newuser;Password=newpassword;Database=postgres";
        }

        public string CheckUserCredentials()
        {
            string result = "";

            using var con = new NpgsqlConnection(_connectionString);
            try
            {
                con.Open();
                result = "Подключение к базе данных установлено.";
            }
            catch (Exception ex)
            {
                result = "Ошибка при подключении к базе данных: " + ex.Message;
            }
            return result;
        }
    }
}
