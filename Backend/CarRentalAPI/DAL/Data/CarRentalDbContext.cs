using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
        {
        }

        public DbSet<CarDetails> CarDetails { get; set; }
        public DbSet<User>Users { get; set; }
        public DbSet<RentalModel> RentalAggrements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id=Guid.NewGuid(),
                    Name="Admin",
                    Email="Admin@admin.com",
                    Password="Admin@123",
                    Role="Admin"
                   
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "User1",
                    Email = "user1@gmail.com",
                    Password = "User@123",
                    Role = "User"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "User2",
                    Email = "user2@gmail.com",
                    Password = "User@123",
                    Role = "User"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "User3",
                    Email = "user3@gmail.com",
                    Password = "User@123",
                    Role = "User"
                }
                );
        }
    }

}
