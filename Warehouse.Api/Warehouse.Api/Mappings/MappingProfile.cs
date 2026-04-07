using AutoMapper;
using Warehouse.Api.DTOs;
using Warehouse.Api.Models;

namespace Warehouse.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Маппинг для чтения пользователей
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team != null ? src.Team.Name : null));

            // Маппинг для создания пользователя (Password переводим в PasswordHash вручную или здесь)
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password)); // В реальном проекте тут нужно хешировать!

            // Product Mappings
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();

            // Team Mappings
            CreateMap<Team, TeamDto>()
                .ForMember(dest => dest.SupervisorName, opt => opt.MapFrom(src => src.Supervisor != null ? $"{src.Supervisor.FirstName} {src.Supervisor.LastName}" : null))
                .ForMember(dest => dest.MemberCount, opt => opt.MapFrom(src => src.Members.Count));
            CreateMap<CreateTeamDto, Team>();
        }
    }
}
