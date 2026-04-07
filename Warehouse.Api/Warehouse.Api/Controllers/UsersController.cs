using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Api.Data;
using Warehouse.Api.Models;
using Warehouse.Api.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            // Получаем всех юзеров (включая данные о команде, если есть)
            var users = await _context.Users.Include(u => u.Team).ToListAsync();
            
            // Маппим сущности БД в DTO
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            
            return Ok(userDtos);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _context.Users
                .Include(u => u.Team)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserDto>(user);
        }

        // POST: api/users
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> PostUser(CreateUserDto createDto)
        {
            // Превращаем пришедший CreateUserDto в сущность БД
            var user = _mapper.Map<User>(createDto);
            user.IsActive = true; 
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(createDto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Маппим результат обратно в UserDto
            var userDto = _mapper.Map<UserDto>(user);

            return CreatedAtAction(nameof(GetUser), new { id = userDto.Id }, userDto);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, CreateUserDto updateDto)
        {
            // Для корректного обновления через DTO, находим сущность
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Копируем новые значения из DTO в нашу сущность
            _mapper.Map(updateDto, user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}