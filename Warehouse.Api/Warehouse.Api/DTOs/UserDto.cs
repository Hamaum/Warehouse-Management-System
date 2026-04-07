namespace Warehouse.Api.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        // Забираем только название команды, чтобы не тащить весь объект
        public string? TeamName { get; set; }
        public bool IsActive { get; set; }
    }
}
