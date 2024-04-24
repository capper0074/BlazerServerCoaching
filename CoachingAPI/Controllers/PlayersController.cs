using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoachingAPI.Data;
using CoachingAPI.Models;
using CoachingAPI.Models.DTOs;

namespace CoachingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController(PlayersDbContext context) : ControllerBase
    {
        private readonly PlayersDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            if (_context.Players == null)
                return NotFound();

            return await _context.Players.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            if (_context.Players == null)
                return NotFound();

            Player? player = await _context.Players.FindAsync(id);

            if (player == null)
                return NotFound();

            return player;
        }

        [HttpGet("detailed")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayerDetailed()
        {
            if (_context.Players == null)
                return NotFound();

            return await _context.Players.Include(p => p.Memberships).ToListAsync();
        }

        [HttpGet("detailed/{id}")]
        public async Task<ActionResult<Player>> GetPlayerDetailed(int id)
        {
            if (_context.Players == null)
                return NotFound();

            Player? player = await _context.Players.FindAsync(id);

            if (player == null)
                return NotFound();

            _context.Entry(player)
                .Collection(p => p.Memberships)
                .Load();

            return player;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, PlayerDTO playerDto)
        {
            Player? player = await _context.Players.FindAsync(id);

            if (player == null)
                return NotFound();

            player.Name = playerDto.Name;

            // Attempt to update the DB
            try
            {
                await _context.SaveChangesAsync();
            }
            // If the player was deleted after we retrieved them from the DB, return a 404
            catch (DbUpdateConcurrencyException) when (!PlayerExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(PlayerDTO playerDto)
        {
            Player player = new()
            {
                Name = playerDto.Name
            };

            if (_context.Players == null)
                return Problem("Entity set 'PlayersDbContext.Players' is null.");
            
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            if (_context.Players == null)
                return NotFound();
            
            Player? player = await _context.Players.FindAsync(id);
            
            if (player == null)
                return NotFound();

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("generate")]
        public async Task<ActionResult<Player>> GeneratePlayer()
        {
            Player player = new()
            {
                Name = "GeneratedPlayer"
            };

            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
        }

        /// <summary>
        /// Determines if a <see cref="Player"/> with a matching ID exists.
        /// </summary>
        /// <param name="id">The ID of the player to look for.</param>
        /// <returns>
        /// <see langword="true"/> if a <see cref="Player"/> with a matching ID exists.<br/>
        /// <see langword="false"/> otherwise.
        /// </returns>
        private bool PlayerExists(int id) => _context.Players.Any(e => e.Id == id);
    }
}
