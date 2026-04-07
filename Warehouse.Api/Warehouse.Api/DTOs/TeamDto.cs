namespace Warehouse.Api.DTOs
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? SupervisorId { get; set; }
        public string? SupervisorName { get; set; }
        public int MemberCount { get; set; }
    }
}
