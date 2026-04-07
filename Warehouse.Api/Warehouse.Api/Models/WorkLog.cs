using System.ComponentModel.DataAnnotations;

namespace Warehouse.Api.Models
{
    public enum ActionType
    {
        Start, 
        Stop, 
        Pause
    }
    public class WorkLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int TaskId {  get; set; }
        public WarehouseTask Task { get; set; }
        [Required]
        public ActionType ActionType { get; set; }
        [Required]
        public DateTime Timestamp {  get; set; }
    }
}
