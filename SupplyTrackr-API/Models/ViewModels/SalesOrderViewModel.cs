using System.ComponentModel.DataAnnotations;

namespace SupplyTrackr_API.Models.ViewModels
{
    public class SalesOrderViewModel
    {
     
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? PaymentType { get; set; }
        public decimal Tax { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public string? Shipping { get; set; }
        public string? ReferenceNumber { get; set; }
        public List<OrderDetailViewModel>? OrderDetails { get; set; }
    }

    public class OrderDetailViewModel
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int QtyOrdered { get; set; }
        public decimal UnitPrice { get; set; }
        public string? UnitOfMesure { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
