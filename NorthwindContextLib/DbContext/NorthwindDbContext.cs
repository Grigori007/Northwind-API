using System;
using Microsoft.EntityFrameworkCore;

namespace NorthwindContextLib
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<CustomerDto> Customers { get; set; }
        public DbSet<EmployeeDto> Employees { get; set; }
        public DbSet<OrderDto> Orders { get; set; }
        public DbSet<OrderDetailDto> OrderDetails { get; set; }
        public DbSet<ProductDto> Products { get; set; }
        public DbSet<ShipperDto> Shippers { get; set; }
        public DbSet<SupplierDto> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryDto>()
                .Property(c => c.CategoryName)
                .IsRequired() // by default, it's true
                .HasMaxLength(15);

            // definig one-to-many relationship
            modelBuilder.Entity<CategoryDto>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<CustomerDto>()
                .Property(c => c.CustomerId)
                .IsRequired()
                .HasMaxLength(5);

            modelBuilder.Entity<CustomerDto>()
                .Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<CustomerDto>()
                .Property(c => c.ContactName)
                .HasMaxLength(30);

            modelBuilder.Entity<CustomerDto>()
                .Property(c => c.Country)
                .HasMaxLength(15);

            modelBuilder.Entity<EmployeeDto>()
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<EmployeeDto>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<EmployeeDto>()
                .Property(c => c.Country)
                .HasMaxLength(15);

            modelBuilder.Entity<ProductDto>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<ProductDto>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products);

            modelBuilder.Entity<ProductDto>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products);

            modelBuilder.Entity<OrderDetailDto>().ToTable("Order Details");

            // defining multi-column main key for OrderDetails table
            modelBuilder.Entity<OrderDetailDto>()
                .HasKey(o => new { o.OrderId, o.ProductId });

            modelBuilder.Entity<SupplierDto>()
                .Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<SupplierDto>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Supplier);
        }
    }
}
    
