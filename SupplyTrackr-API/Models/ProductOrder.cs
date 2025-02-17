using System.ComponentModel.DataAnnotations;

namespace SupplyTrackr_API.Models
{
    public class ProductOrder
    {
        [Key]
        public required int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int QuantityInStock { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
