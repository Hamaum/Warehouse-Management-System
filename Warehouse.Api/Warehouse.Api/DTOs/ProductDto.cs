namespace Warehouse.Api.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string SKU { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
    }
}
