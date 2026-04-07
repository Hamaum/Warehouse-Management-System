using System.ComponentModel.DataAnnotations;
using Warehouse.Api.Models;

namespace Warehouse.Api.DTOs
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        public UserRole Role { get; set; }
    }
}
