using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesDatePrediction.Models.DTOs;
using SalesDatePrediction.Models.Entities;

namespace SalesDatePrediction.Context
{
    public class DBDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DBDbContext(DbContextOptions<DBDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CustomerWithOrderDatesDto> CustomerWithOrderDatesDto { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customers", "Sales") 
                .HasKey(c => c.CustId); 

            modelBuilder.Entity<Order>()
                .ToTable("Orders", "Sales")
                .HasKey(o => o.orderid);

            modelBuilder.Entity<Employee>()
                .ToTable("Employees", "HR")
                .HasKey(e => e.EmpId);

            modelBuilder.Entity<Shipper>()
                .ToTable("Shippers", "Sales")
                .HasKey(s => s.ShipperId);

            modelBuilder.Entity<Product>()
                .ToTable("Products", "Production")
                .HasKey(p => p.Id);

            modelBuilder.Entity<OrderDetail>()
                .ToTable("OrderDetails", "Sales")
                .HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<CustomerWithOrderDatesDto>(entity =>
            {
                entity.HasNoKey();                
                entity.ToView("CustomerOrderPredictions", "Sales"); 
            });

            base.OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

    }
}
