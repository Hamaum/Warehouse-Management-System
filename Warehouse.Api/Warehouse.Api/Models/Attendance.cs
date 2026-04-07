using System.ComponentModel.DataAnnotations;

namespace Warehouse.Api.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public DateTime CheckInTime { get; set; }

        public DateTime? CheckOutTime { get; set; } // Null, пока смена не окончена
    }
}
