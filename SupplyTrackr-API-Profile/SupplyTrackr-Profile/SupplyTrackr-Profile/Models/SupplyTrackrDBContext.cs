using Microsoft.EntityFrameworkCore;

namespace SupplyTrackr_Profile.Models
{
    public class SupplyTrackrDBContext :DbContext
    {
        public SupplyTrackrDBContext(DbContextOptions options) : base(options) { 
        
        
        
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet <StockMovement> StockMovements { get; set; }
        
        public DbSet <SalesOrder> SalesOrders { get; set; }
        public DbSet <OrderDetail> OrderDetails { get; set; }
        public DbSet <PurchaseOrder> PurchaseOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.SalesOrder) //Orderdetail has one SalesOrder
                .WithMany(so => so.OrderDetails) //Salesorder has many OrderDets
                .HasForeignKey(od => od.OrderId) //Foreign Key in OrderDetail
                .HasPrincipalKey(so => so.OrderId) //Ensure it matches OrderID in SalesOrder
                .OnDelete(DeleteBehavior.Cascade); //Cascade delete bahavior

            modelBuilder.Entity<SalesOrder>()
                .HasKey(so => so.Id); //PK for SO
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => od.Id); //PK for OD
        }
    }
}
