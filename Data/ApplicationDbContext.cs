using System;
using Microsoft.EntityFrameworkCore;
using testmvc.Models;
using testmvc.Data;

namespace testmvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasOne(r => r.Role).WithMany(a => a.Accounts).HasForeignKey(r => r.RoleID);
            modelBuilder.Entity<Product>().HasOne(c => c.Category).WithMany(a => a.Products).HasForeignKey(c => c.CatID);
            modelBuilder.Entity<OrderDetail>().HasOne(o => o.Order).WithMany(o => o.OrderDetails).HasForeignKey(o => o.OrderID);
            modelBuilder.Entity<OrderDetail>().HasOne(o => o.Product).WithMany(o => o.OrderDetails).HasForeignKey(o => o.ProductID);
            modelBuilder.Entity<Order>().HasOne(c => c.Customer).WithMany(o => o.Orders).HasForeignKey(c => c.CustomerID);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<New> News { get; set; }

    }
}

