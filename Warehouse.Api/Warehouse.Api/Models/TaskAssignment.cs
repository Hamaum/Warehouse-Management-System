using System.ComponentModel.DataAnnotations;

namespace Warehouse.Api.Models
{
    public enum StatusesTaskAssignment
    {
        Active,
        Inactive
    }
    public class TaskAssignment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TaskId { get; set; }
        public WarehouseTask Task { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public StatusesTaskAssignment Status { get; set; }
        [Required]
        public DateTime AssignedAt { get; set; }
    }
}
