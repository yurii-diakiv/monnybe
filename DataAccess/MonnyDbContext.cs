using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess
{
    public class MonnyDbContext: DbContext
    {
        public MonnyDbContext():
            base() { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Limitation> Limitations { get; set; }
        public DbSet<CustomCategory> CustomCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categories = new List<Category>
            {
                new Category {Id = 1, Name = "Food"},
                new Category {Id = 2, Name = "Health"},
                new Category {Id = 3, Name = "Traveling"},
                new Category {Id = 4, Name = "Clothes"},
                new Category {Id = 5, Name = "Cafes"},
                new Category {Id = 6, Name = "Transport"},
                new Category {Id = 7, Name = "Entertainments"}
            };

            modelBuilder.Entity<Category>().HasData(categories);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MonnyDataBase;Trusted_Connection=True;");
            // optionsBuilder.UseNpgsql(
            //     "Host=ec2-54-247-118-139.eu-west-1.compute.amazonaws.com;Port=5432;Database=d5j8dn5a23j0bl;Username=ecevrottkkwshs;Password=33ffe6ce75f3d360f2a4431fe8119657131e7a2735a46c3d86bdb3b882d4cff2"
            // );
            // optionsBuilder.UseSqlServer(
            //     "Server=ec2-54-247-118-139.eu-west-1.compute.amazonaws.com;Database=d5j8dn5a23j0bl;User Id=ecevrottkkwshs;Password=33ffe6ce75f3d360f2a4431fe8119657131e7a2735a46c3d86bdb3b882d4cff2;SSL Mode=Require;TrustServerCertificate=True;"
            // );
            optionsBuilder.UseNpgsql(
                "Server=ec2-54-247-118-139.eu-west-1.compute.amazonaws.com;Database=d5j8dn5a23j0bl;User Id=ecevrottkkwshs;Password=33ffe6ce75f3d360f2a4431fe8119657131e7a2735a46c3d86bdb3b882d4cff2;SSL Mode=Require;TrustServerCertificate=True;"
            );
        }
    }
}
