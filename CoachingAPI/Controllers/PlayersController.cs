using CoachingAPI.Data;
using CoachingAPI.DataFix;
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
        private readonly DataBase_update _dataBase_Update1;

        public PlayersController(PlayersDbContext context, DataBase_update dataBase_Update)
        {
            _context = context;
            _dataBase_Update1 = dataBase_Update;
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
        public async Task<IActionResult> PutPlayer(Guid id, Player player)
        {
            if (id != player.PlayerId)
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

            return CreatedAtAction("GetPlayer", new { id = player.PlayerId }, player);
        }

        //POST: apy/Players/match/
        //[HttpPost]
        //public async Task<ActionResult> PostMatch(Match match)
        //{
        //    return CreatedAtAction("GetMatch", new { id = match.MatchId }, match);
        //}



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

        private bool PlayerExists(Guid id)
        {
            return (_context.Players?.Any(e => e.PlayerId == id)).GetValueOrDefault();
        }
    }
}
