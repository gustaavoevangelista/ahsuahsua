using Final_Project_2._1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NuGet.Protocol.Core.Types;
using System.IO;
using Microsoft.Extensions.Options;

namespace Final_Project_2._1.DatabaseContext
{
    internal class MyDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("DbSettings.json")
                .Build();

            string connectionStr = configuration.GetConnectionString("MyDbContext");

            optionsBuilder.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr), options =>
            {
                options.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: System.TimeSpan.FromSeconds(2),
                    errorNumbersToAdd: null);
            });


        }
    }
}
