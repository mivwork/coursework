using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using model.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.DataAccess
{
    /*
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
    */


    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Clock> clock{ get; set; }
        public DbSet<Brend_clock> brend_clock{ get; set; }
        public DbSet<Country_clock> country_clock { get; set; }
        public DbSet<Model_clock> model_clock { get; set; }
        public DbSet<Status_clock> status_clock { get; set; }
        public DbSet<Users> users { get; set; }
        
        //public MyDbContext context = new MyDbContext();
        


    public string CheckUserCredentials()
        {
            string result = "";
            var context = new MyDbContext();
                try
            {
                var users = context.clock.ToList();
                result = "Подключение к базе данных установлено.";
            }
            catch (Exception ex)
            {
                result = "Ошибка при подключении к базе данных: " + ex.Message;
            }
            return result;
        }

        public bool LoginAndPassword(string login, string password)
        {
            var context = new MyDbContext();
            var user = context.users.Where(u => u.login == login).FirstOrDefault();
            var pass = context.users.Where(u => u.password == password).FirstOrDefault();
            if (user != null && pass != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Clock> getDataClock()
        {
            var context = new MyDbContext();
            List<Clock> data = context.clock.ToList();

            // Вернуть список объектов
            return data;
        }


    }

}