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



        public bool Update(Match match)
        {
            //Mapstats1 er det første hold indtastede i listen.
            MapStats mapStats1 = new MapStats();
            MapStats mapStats2 = new MapStats();
            GeneralStats generalStats1 = new GeneralStats();
            GeneralStats generalStats2 = new GeneralStats();

            if (match == null)
            {
                return false;
            }

            foreach(Team team in match.Teams)
            {
                bool team1Exist = _context.Teams.Any(t => t.Name == team.Name);
                if(team1Exist ==false)
                {
                    _context.Teams.Add(team);
                }
                if (match.Winner.Name == team.Name)
                {
                   
                }
               
               
            }
            mapStats1.TotalRoundsPlayed = match.TeamPerformanceStats.CTRoundsPlayed + match.TeamPerformanceStats.TRoundsPlayed;
            mapStats1.CtRoundsPlayed += match.TeamPerformanceStats.CTRoundsPlayed;
            mapStats1.CtPistolRoundsPlayed++;
            mapStats1.CtPistolRoundsWon += match.TeamPerformanceStats.CTPistolRoundWon;
            mapStats1.TRoundsPlayed += match.TeamPerformanceStats.TRoundsPlayed;
            mapStats1.TPistolRoundsPlayed++;
            mapStats1.TPistolRoundsWins += match.TeamPerformanceStats.TPistolRoundWon;

            mapStats2.TotalRoundsPlayed = mapStats1.TotalRoundsPlayed;
            mapStats2.CtRoundsPlayed += mapStats1.TRoundsPlayed;
            mapStats2.CtPistolRoundsPlayed++;
            if(match.TeamPerformanceStats.CTPistolRoundWon > 0)
            {
                mapStats2.CtPistolRoundsWon +=0;
            }
            else
            {
                mapStats2.CtPistolRoundsWon= 1;
            }

            return true;
        }



    }
}
