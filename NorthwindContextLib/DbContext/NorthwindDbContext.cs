using Microsoft.EntityFrameworkCore;
using System.Linq;
//using Microsoft.EntityFrameworkCore.Proxies;

namespace NorthwindContextLib
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions options) : base(options)
        {
            // enabling eager loading 
            //Categories.Include(c => c.Products).ToList();
            //Customers.Include(c => c.Orders).ToList();
            //Employees.Include(c => c.Manager);
            //Employees.Include(c => c.Orders).ToList();
            //Orders.Include(c => c.Customer);
            //Orders.Include(c => c.Employee);
            //Orders.Include(c => c.Shipper);
            //Orders.Include(c => c.OrderDetails).ToList();
            //OrderDetails.Include(c => c.Order);
            //OrderDetails.Include(c => c.Product);
            //Products.Include(c => c.Supplier);
            //Products.Include(c => c.Category);
            //Shippers.Include(c => c.Orders).ToList();
            //Suppliers.Include(c => c.Products).ToList();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Category
            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired() // by default, it's true
                .HasMaxLength(15);

            // definig one-to-many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Category>()
                .Ignore(c => c.EntityId);
            #endregion

            #region Customer
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerId)
                .IsRequired()
                .HasMaxLength(5);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Customer>()
                .Property(c => c.ContactName)
                .HasMaxLength(30);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Country)
                .HasMaxLength(15);

            modelBuilder.Entity<Customer>()
                .Ignore(c => c.EntityId);
            #endregion

            #region Employee
            modelBuilder.Entity<Employee>()
                .HasKey(c => c.EmployeeId);

            //modelBuilder.Entity<Employee>()
            //    .HasOne(c => c.Manager)
            //    .WithMany()

            modelBuilder.Entity<Employee>()
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Employee>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Employee>()
                .Property(c => c.Country)
                .HasMaxLength(15);

            modelBuilder.Entity<Employee>()
                .Ignore(c => c.EntityId);
            #endregion

            #region Order
            modelBuilder.Entity<Order>()
                .HasKey(c => c.OrderId);

            modelBuilder.Entity<Order>()
                .Ignore(c => c.EntityId);
            #endregion

            #region OrderDetail
            modelBuilder.Entity<OrderDetail>().ToTable("Order Details");

            // defining multi-column main key for OrderDetails table
            modelBuilder.Entity<OrderDetail>()
                .HasKey(o => new { o.OrderId, o.ProductId });

            modelBuilder.Entity<OrderDetail>()
                .Ignore(c => c.EntityId);
            #endregion

            #region Product
            modelBuilder.Entity<Product>()
                .HasKey(c => c.ProductId);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products);

            modelBuilder.Entity<Product>()
                .Ignore(c => c.EntityId);
            #endregion

            #region Shipper
            modelBuilder.Entity<Shipper>()
                 .HasKey(c => c.ShipperId);

            modelBuilder.Entity<Shipper>()
                .Ignore(c => c.EntityId);
            #endregion

            #region Supplier
            modelBuilder.Entity<Supplier>()
                .HasKey(c => c.SupplierId);

            modelBuilder.Entity<Supplier>()
                .Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Supplier);

            modelBuilder.Entity<Supplier>()
                .Ignore(c => c.EntityId);
            #endregion
        }
    }
}
    
