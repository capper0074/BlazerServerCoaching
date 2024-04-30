using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoachingAPI.Data;
using CoachingAPI.Models;
using CoachingAPI.Models.DTOs;

namespace CoachingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController(PlayersDbContext context) : ControllerBase
    {
        private readonly PlayersDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            if (_context.Teams == null)
                return NotFound();

            return await _context.Teams.Include(t => t.Memberships).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            if (_context.Teams == null)
                return NotFound();

            Team? team = await _context.Teams.FindAsync(id);

            if (team == null)
                return NotFound();

            _context.Entry(team)
                .Collection(t => t.Memberships)
                .Load();

            return team;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, TeamDTO teamDto)
        {
            if (_context.Teams == null)
                return NotFound();

            Team? team = await _context.Teams.FindAsync(id);

            if (team == null)
                return BadRequest($"No Team exists with id = {id}.");

            // Update the team
            team.Name = teamDto.Name;
            team.IsMatchMaking = teamDto.IsMatchMaking;

            // Attempt to update the DB
            try
            {
                await _context.SaveChangesAsync();
            }
            // If the team was deleted after we retrieved it from the DB, return a 404
            catch (DbUpdateConcurrencyException) when (!TeamExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(TeamDTO teamDto)
        {
            Team team = new()
            {
                Name = teamDto.Name,
                IsMatchMaking = teamDto.IsMatchMaking
            };

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, team);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            if (_context.Teams == null)
                return NotFound();

            Team? team = await _context.Teams.FindAsync(id);

            if (team == null)
                return NotFound();

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Determines if a <see cref="Team"/> with a matching ID exists.
        /// </summary>
        /// <param name="id">The ID of the team to look for.</param>
        /// <returns>
        /// <see langword="true"/> if a <see cref="Team"/> with a matching ID exists.<br/>
        /// <see langword="false"/> otherwise.
        /// </returns>
        private bool TeamExists(int id) => _context.Teams.Any(e => e.Id == id);
    }
}
