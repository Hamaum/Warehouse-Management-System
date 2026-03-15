using System.ComponentModel.DataAnnotations;

namespace Warehouse.Api.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string SKU { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(20)]
        public string Location { get; set; } = string.Empty;
    }
}