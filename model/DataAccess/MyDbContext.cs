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
using BCrypt.Net;

namespace model.DataAccess
{
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
    }
}