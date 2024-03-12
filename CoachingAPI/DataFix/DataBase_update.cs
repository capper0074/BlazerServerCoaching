using CoachingAPI.Data;
using CoachingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoachingAPI.DataFix
{
    public class DataBase_update
    {
        private readonly PlayersDbContext _context;
        public DataBase_update(PlayersDbContext context) 
        {
            _context = context;
        }



        public async Task<bool> Update(Match match)
        {
      
            if (match == null)
            {
                return false;
            }
            _context.Add(match);
            await _context.SaveChangesAsync();
       
            return true;
        }



    }
}
