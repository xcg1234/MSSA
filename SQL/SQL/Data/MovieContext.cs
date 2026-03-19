using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ModMigrationsDemo.Models;

namespace ModMigrationsDemo.Data
{
    public class MovieContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=MSI;initial catalog=CCAD22Movies;integrated security=True;encrypt=False;trustservercertificate=True;MultipleActiveResultSets=True");
        }
        //data seeding

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Title = "The Shawshank Redemption", ReleaseDate = new DateTime(1994, 9, 22), Genre="Action" },
                new Movie { MovieId = 2, Title = "The Godfather", ReleaseDate = new DateTime(1972, 3, 24), Genre = "Story" },
                new Movie { MovieId = 3, Title = "The Dark Knight", ReleaseDate = new DateTime(2008, 7, 18), Genre = "Action" });
        }
    }
}
