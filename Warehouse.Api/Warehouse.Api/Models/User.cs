using System.ComponentModel.DataAnnotations;

namespace Warehouse.Api.Models
{
    public enum UserRole 
    { 
        WarehouseWorker, 
        Manager, 
        Admin 
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        // ID of the team the user belongs to (Foreign Key)
        public int? TeamId { get; set; }
        public bool IsActive { get; set; }
    }
}
