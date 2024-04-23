using CoachingAPI.Data;
using CoachingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoachingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayersDbContext _context;

        public PlayersController(PlayersDbContext context)
        {
            _context = context;
            
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            if (_context.Players == null)
            {
                return NotFound();
            }

            return await _context.Players.ToListAsync();
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(Guid id)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }   

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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



        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            if (_context.Players == null)
            {
                return Problem("Entity set 'PlayersDbContext.Players'  is null.");
            }
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }

        //POST: apy/Players/match/
        [HttpPost("Matchpost")]
        public async Task<ActionResult> PostMatch(DateTime date, MatchPlatform matchPlatform, MapName map, int fK_WinnerTeamId, List<int> teams, int winner)
        {
            Team winnerteam = await _context.Teams.FindAsync(winner);
            List<Team> matchteams = _context.Teams.Where(t => teams.Contains(t.Id)).ToList();
            Map mapused = _context.Maps.Find(map);
            //_context.Add(new Match(date, matchPlatform,mapused,fK_WinnerTeamId,matchteams));
            _context.SaveChanges();
            return Ok();

        }



        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return (_context.Players?.Any(e => e.Id == id)).GetValueOrDefault();
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

            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }
    }
}
