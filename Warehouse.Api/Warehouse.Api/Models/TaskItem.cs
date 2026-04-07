using System.ComponentModel.DataAnnotations;

namespace Warehouse.Api.Models
{
    public enum TaskItemStatus
    {
        ToPick,
        Picked
    }
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TaskId { get; set; }
        public WarehouseTask Task { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public TaskItemStatus Status {  get; set; }

    }
}
