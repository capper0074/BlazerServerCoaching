using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoachingAPI.Data;
using CoachingAPI.Models;
using CoachingAPI.Models.DTOs;

namespace CoachingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController(PlayersDbContext context) : ControllerBase
    {
        private readonly PlayersDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatches()
        {
            if (_context.Matches == null)
                return NotFound();

            return await _context.Matches
                .Include(m => m.Map)
                .Include(m => m.Teams)
                .ThenInclude(t => t.Memberships)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            if (_context.Matches == null)
                return NotFound();

            Match? match = await _context.Matches.FindAsync(id);

            if (match == null)
                return NotFound();
            
            // Explicitly load related entities
            _context.Entry(match)
                .Reference(m => m.Map)
                .Load();

            _context.Entry(match)
                .Collection(m => m.Teams)
                .Load();

            foreach (Team team in match.Teams)
            {
                _context.Entry(team)
                    .Collection(t => t.Memberships)
                    .Load();
            }

            return match;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(int id, MatchDTO matchDto)
        {
            Match? match = await _context.Matches.FindAsync(id);

            if (match == null)
                return NotFound();

            // Remove the match from the teams that are currently associated with it
            _context.Entry(match).Collection(m => m.Teams).Load();

            foreach (Team team in match.Teams)
                team.Matches.Remove(match);

            // Update the match
            match.Date = matchDto.Date;
            match.MatchPlatform = matchDto.MatchPlatform;
            match.MapName = matchDto.MapName;
            match.WinnerTeamId = matchDto.WinnerTeamId;

            match.Teams.Clear();
            foreach (int teamId in matchDto.TeamIds)
            {
                Team? team = await _context.Teams.FindAsync(teamId);

                if (team == null)
                    return NotFound();

                match.Teams.Add(team);
            }

            // Attempt to update the DB
            try
            {
                await _context.SaveChangesAsync();
            }
            // If the match was deleted after we retrieved them from the DB, return a 404
            catch (DbUpdateConcurrencyException) when (!MatchExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(MatchDTO matchDto)
        {
            // Get the map
            Map? map = _context.Maps.Find(matchDto.MapName);

            if (map == null)
                return BadRequest($"No Map exists with MapName = {matchDto.MapName}");

            // Get the winning team
            Team? winningTeam = _context.Teams.Find(matchDto.WinnerTeamId);

            if (winningTeam == null)
                return BadRequest($"No Team exists with Id = {matchDto.WinnerTeamId}.");

            // Get participating teams
            List<Team> teams = [];

            foreach (int teamId in matchDto.TeamIds)
            {
                Team? team = await _context.Teams.FindAsync(teamId);

                if (team == null)
                    return BadRequest($"No Team exists with Id = {teamId}.");

                teams.Add(team);
            }

            // Create the new match
            Match match = new()
            {
                Date = matchDto.Date,
                MatchPlatform = matchDto.MatchPlatform,
                MapName = matchDto.MapName,
                WinnerTeamId = matchDto.WinnerTeamId,
                Map = map,
                Winner = winningTeam,
                Teams = teams
            };

            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMatch), new { id = match.Id }, match);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);

            if (match == null)
                return NotFound();            

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Determines if a <see cref="Match"/> with a matching ID exists.
        /// </summary>
        /// <param name="id">The ID of the match to look for.</param>
        /// <returns>
        /// <see langword="true"/> if a <see cref="Match"/> with a matching ID exists.<br/>
        /// <see langword="false"/> otherwise.
        /// </returns>
        private bool MatchExists(int id) => _context.Matches.Any(e => e.Id == id);
    }
}
