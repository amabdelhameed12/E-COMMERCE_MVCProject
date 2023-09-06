﻿using Microsoft.EntityFrameworkCore;

namespace E_COMMERCEMVC.Models
{
    public class Context:DbContext
    {
        public Context() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public enum PaymentMethod
        {
            CreditCard,
            DebitCard,
            PayPal,
            Cash,
        }
    }
}
