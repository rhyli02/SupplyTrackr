using System.ComponentModel.DataAnnotations;

namespace SupplyTrackr_API.Models
{
    public class SalesOrder
    {
        [Key]
        public required int Id { get; set; }
        public required int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? PaymentType { get; set; }
        public decimal Tax { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public string? Shipping { get; set; }

        public string? ReferenceNumber { get; set; }


        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
