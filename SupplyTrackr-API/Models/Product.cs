using System.ComponentModel.DataAnnotations;

namespace SupplyTrackr_API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? SKU { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public string? UnitOfMesure { get; set; }
        public int QuantityInStock { get; set; }
        public int SupplierId { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastModified { get; set; }
        

        
    }
}
