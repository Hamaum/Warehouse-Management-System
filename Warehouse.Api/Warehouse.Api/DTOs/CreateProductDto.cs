using System.ComponentModel.DataAnnotations;

namespace Warehouse.Api.DTOs
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(50)]
        public string SKU { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(20)]
        public string Location { get; set; } = string.Empty;

        public int StockQuantity { get; set; }
    }
}
