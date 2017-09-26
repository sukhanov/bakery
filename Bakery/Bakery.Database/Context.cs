using System;
using Bakery.Database.Models;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Bakery.Database
{
    public class Context : DbContext
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;

        public Context(string connectionString)
        {
            _connectionString = connectionString;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public DbSet<Product> Products { get; set; }

        public void Migrate()
        {
            try
            {
                _logger.Info($"MigrateDb. Connection string: {_connectionString}");
                Database.Migrate();
            }
            catch (Exception e)
            {
                _logger.Error(e, $"MigrateDb. Error: {e}");
                throw new Exception("MigrateDb error. See logs");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}