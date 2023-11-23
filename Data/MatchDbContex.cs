using BlazerServerCoaching.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazerServerCoaching.Data
{
    public class MatchDbContex : IdentityDbContext<CoachingUser>
    {
        public MatchDbContex(DbContextOptions<MatchDbContex> options) : base(options)
        {

        }

        public DbSet<Match> Matchs { get; set; }
    }
}
