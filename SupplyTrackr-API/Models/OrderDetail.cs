using System.ComponentModel.DataAnnotations;

namespace SupplyTrackr_API.Models
{
    public class OrderDetail
    {
        [Key]
        public required int OrderDetailId { get; set; }
       
        public required int OrderId { get; set; }
       
        public required int ProductId { get; set; }
       
        public required int QtyOrdered { get; set; }
       
        public decimal UnitPrice { get; set; }
       
        public string? UnitOfMesure { get; set; }
       
        public decimal TotalAmount { get; set; }





    }
}
