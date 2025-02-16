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
    }
}
