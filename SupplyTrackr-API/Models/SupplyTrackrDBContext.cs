using Microsoft.EntityFrameworkCore;

namespace SupplyTrackr_API.Models
{
    public class SupplyTrackrDBContext : DbContext

    {
        public SupplyTrackrDBContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between SalesOrder and OrderDetail (string type for OrderId)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.SalesOrder)  // OrderDetail has one SalesOrder
                .WithMany(so => so.OrderDetails)  // SalesOrder has many OrderDetails
                .HasForeignKey(od => od.OrderId)  // Foreign Key in OrderDetail
                .HasPrincipalKey(so => so.OrderId)  // Ensure it matches the OrderId in SalesOrder
                .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete behavior

            modelBuilder.Entity<SalesOrder>()
                .HasKey(so => so.Id);  // Primary Key for SalesOrder

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => od.Id);  // Primary Key for OrderDetail
        }
    }
}
