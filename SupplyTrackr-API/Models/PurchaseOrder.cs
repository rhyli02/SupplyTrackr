using System.ComponentModel.DataAnnotations;

namespace SupplyTrackr_API.Models
{
    public class PurchaseOrder
    {
        [Key]
        
        public required int Id { get; set; }
        public required string PONumber { get; set; }          // Unique identifier for the purchase order
        public DateTime PODate { get; set; }          // The date the purchase order is created
        public required string SupplierId { get; set; }
        public string? SupplierName { get; set; }        // Vendor name
        public string? ShippingAddress { get; set; }   // Shipping address
        public string? PaymentTerms { get; set; }      // Payment terms
        public List<ProductOrder>? OrderProducts { get; set; } // List of items being ordered
        public decimal Subtotal { get; set; }         // Total cost of ordered items before taxes and discounts
        public decimal TaxAmount { get; set; }        // Tax charged on the order
        public decimal Discount { get; set; }         // Discount applied
        public decimal TotalAmount { get; set; }      // Final amount to be paid after tax and discounts
        public DateTime DeliveryDate { get; set; }    // Expected delivery date
        public string? DeliveryStatus { get; set; }    // Current delivery status
        public string? OrderStatus { get; set; }       // Current status of the purchase order
        public string? PurchaseOrderType { get; set; } // Type of purchase order (e.g., standard, blanket, contract)
        public string? AuthorizedBy { get; set; }      // Person or department who authorized the order
        public string? Notes { get; set; }             // Any additional comments or special instructions

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public required string CreatedBy { get; set; }
        public required string LastModified { get; set; }

    }
}
