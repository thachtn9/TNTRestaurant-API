using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EF
{
    public class MyBDContext : DbContext 
    { 
        public MyBDContext(DbContextOptions options) : base(options)
        {

        }    
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1 nhà hàng -> nhiều bàng
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");
                entity.HasKey(r => r.RestaurantID);
                entity.HasMany(r => r.Tables)
                .WithOne(t => t.Restaurant)
                .HasForeignKey(t => t.RestaurantID);
            });
            // 1 bàn có nhiều order
            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Table");
                entity.HasKey(r => r.TableID);
                entity.HasMany(t => t.Orders)
                .WithOne(o => o.Table)
                .HasForeignKey(o => o.TableID);
            });
            // 1 khách hàng có nhiều order
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");
                entity.HasKey(r => r.CustomerID);
                entity.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerID);
            });
            // 1 Order có nhiều OrderDetail
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(r => r.OrderID);
                entity.HasMany(c => c.OrderDetails)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderID);
            });
            // 1 Product có nhiều OrderDetail
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(r => r.ProductID);
                entity.HasMany(c => c.OrderDetails)
                .WithOne(o => o.Product)
                .HasForeignKey(o => o.ProductID);
            });
            //(n-n) 1 Order có nhiều OrderDetail -  1 Product có nhiều OrderDetail
            //Quan hệ nhiều nhiều có bảng chung gian là orderDetail
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");
                entity.HasKey(r => new { r.ProductID, r.OrderID});
                entity.HasOne(c => c.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(o => o.OrderID);
                entity.HasOne(c => c.Product)
               .WithMany(o => o.OrderDetails)
               .HasForeignKey(o => o.ProductID);
              
            });          
        }
    }
}
