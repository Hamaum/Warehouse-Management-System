using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Warehouse.Api.Data;
using Warehouse.Api.Models;
using Warehouse.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Warehouse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TeamsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TeamsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
        {
            var teams = await _context.Teams
                .Include(t => t.Supervisor)
                .Include(t => t.Members)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<TeamDto>>(teams));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDto>> GetTeam(int id)
        {
            var team = await _context.Teams
                .Include(t => t.Supervisor)
                .Include(t => t.Members)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (team == null) return NotFound();

            return Ok(_mapper.Map<TeamDto>(team));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<TeamDto>> PostTeam(CreateTeamDto createDto)
        {
            var team = _mapper.Map<Team>(createDto);
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            // Загружаем навигационные свойства, если нужно, но пока их нет
            var teamDto = _mapper.Map<TeamDto>(team);
            return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, teamDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> PutTeam(int id, CreateTeamDto updateDto)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();

            _mapper.Map(updateDto, team);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
