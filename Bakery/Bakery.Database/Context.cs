using System;
using System.Collections.Generic;
using Bakery.Common.Infra.Enums;
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

                var created = Database.EnsureCreated();

                if (!created)
                {
                    Database.Migrate();
                }
                else
                {
                    AddTestData();
                }
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

        private void AddTestData()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Круассан с вареной сгущенкой",
                    BakingTime = DateTime.Now,
                    LifeHours = 18,
                    FreshHours = 10,
                    Price = 45,
                    Type = BakeryType.Croissant
                },
                new Product
                {
                    Name = "Крендель с сыром",
                    BakingTime = DateTime.Now,
                    LifeHours = 20,
                    FreshHours = 16,
                    Price = 35,
                    Type = BakeryType.Pretzel
                },
                new Product
                {
                    Name = "Багет фитнес",
                    BakingTime = DateTime.Now,
                    LifeHours = 48,
                    FreshHours = 24,
                    Price = 60,
                    Type = BakeryType.Baguette
                },
                new Product
                {
                    Name = "Батон с маком",
                    BakingTime = DateTime.Now,
                    LifeHours = 48,
                    FreshHours = 24,
                    Price = 37,
                    Type = BakeryType.Loaf
                },
                new Product
                {
                    Name = "Сметанник",
                    BakingTime = DateTime.Now,
                    LifeHours = 20,
                    FreshHours = 16,
                    Price = 59,
                    Type = BakeryType.SourCream
                },
                new Product
                {
                    Name = "Французский багет",
                    BakingTime = DateTime.Now,
                    LifeHours = 48,
                    FreshHours = 24,
                    Price = 31,
                    Type = BakeryType.Baguette
                },
                new Product
                {
                    Name = "Крендель с солью",
                    BakingTime = DateTime.Now,
                    LifeHours = 20,
                    FreshHours = 16,
                    Price = 23,
                    Type = BakeryType.Pretzel
                },
                new Product
                {
                    Name = "Круассан с абрикосовым джемом",
                    BakingTime = DateTime.Now,
                    LifeHours = 18,
                    FreshHours = 10,
                    Price = 46,
                    Type = BakeryType.Croissant
                },
                new Product
                {
                    Name = "Батон нарезной",
                    BakingTime = DateTime.Now,
                    LifeHours = 48,
                    FreshHours = 24,
                    Price = 43,
                    Type = BakeryType.Loaf
                },
                new Product
                {
                    Name = "Круассан с вишней",
                    BakingTime = DateTime.Now,
                    LifeHours = 18,
                    FreshHours = 10,
                    Price = 70,
                    Type = BakeryType.Croissant
                }
            };
            foreach (var product in products)
            {
                Products.Add(product);
            }
            SaveChanges();
        }
    }
}