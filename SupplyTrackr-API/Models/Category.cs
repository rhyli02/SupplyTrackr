using System.ComponentModel.DataAnnotations;

namespace SupplyTrackr_API.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }



    }
}
