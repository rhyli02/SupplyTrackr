namespace SupplyTrackr_API.Models.ViewModels
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        public required string SupplierId { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public DateTime CreatedDate { get; set; }
        public required string CreatedBy { get; set; }
    }
}
