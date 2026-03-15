using System.ComponentModel.DataAnnotations;

namespace Warehouse.Api.Models
{
    public enum TaskStatus
    {
        New,
        InProgress,
        OnHold,
        Completed
    }
    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }
    public class WarehouseTask
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status {  get; set; }
        public TaskPriority Priority { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeadlineAt { get; set; }
    }
}
