using System.ComponentModel.DataAnnotations;

namespace Warehouse.Api.Models
{
    public enum RequestType
    {
        Vacation,       // Urlop
        DayOff,         // Dzień wolny
        Overtime        // Nadgodziny
    }

    public enum RequestStatus
    {
        Pending,        // Oczekujące
        Approved,       // Zatwierdzone
        Rejected        // Odrzucone
    }

    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public RequestType Type { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [StringLength(500)]
        public string Reason { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
