using System.ComponentModel.DataAnnotations;

namespace Warehouse.Api.Models
{
    // Entity representing a team of warehouse workers
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        // ID of the manager assigned to the team (Foreign Key)
        public int SupervisorId { get; set; }
    }
}