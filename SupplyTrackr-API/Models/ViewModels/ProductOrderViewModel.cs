namespace SupplyTrackr_API.Models.ViewModels
{
    public class ProductOrderViewModel
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int QuantityInStock { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
