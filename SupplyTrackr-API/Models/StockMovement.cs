namespace SupplyTrackr_API.Models
{
    public class StockMovement
    {
        public int StockMovementId { get; set; }
        public int ProductId { get; set; }
        public string MovementType { get; set; }
        public int QuantityChanged { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }

        public virtual Product Product { get; set; }
    }
}
