using System.ComponentModel.DataAnnotations;

namespace Warehouse.Api.DTOs
{
    public class CreateTeamDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public int? SupervisorId { get; set; }
    }
}
