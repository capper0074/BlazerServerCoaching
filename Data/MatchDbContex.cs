using BlazerServerCoaching.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazerServerCoaching.Data
{
    public class MatchDbContex : DbContext
    {
        public MatchDbContex(DbContextOptions<MatchDbContex> options) : base(options)
        {

        }


        public DbSet<Match> Matchs { get; set; }
    }
}
