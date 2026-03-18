using Assignment10_3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment10_3.Data
{
    internal class CarContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=CarLogDatabase;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        }

        //some data seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car { VIN = "1HGCM82633A004352", Make = "Honda", Model = "Accord", Year = 2003 },
                new Car { VIN = "1FAFP404X1F123456", Make = "Ford", Model = "Mustang", Year = 2001 },
                new Car { VIN = "2T1BR32E54C123456", Make = "Toyota", Model = "Corolla", Year = 2004 }
            );
        }
    }
}

