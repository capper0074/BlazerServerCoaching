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

            //foreach(Team team in match.Teams)
            //{
            //    bool team1Exist = _context.Teams.Any(t => t.Name == team.Name);
            //    if(team1Exist ==false)
            //    {
            //        _context.Teams.Add(team);
            //    }          
               
            //}
            if(match.Winner.Name == match.Teams[0].Name)
            {
                mapStats1.Wins++;
                generalStats1.Wins++;
                mapStats2.Losses++;
                generalStats2.Losses++;
            }
            else
            {
                mapStats1.Losses++;
                generalStats1.Losses++;
                mapStats2.Wins++;
                generalStats2.Wins++;
            }
            if(match.TeamMatchStats.CTPistolRoundWon > 0)
            {                
                mapStats2.CtPistolRoundsLost += 1;
                mapStats1.CtPistolRoundsWins += 1;
            }
            else
            {
                mapStats1.CtPistolRoundsLost += 1;
                mapStats2.CtPistolRoundsWins += 1;
            }
            if (match.TeamMatchStats.TPistolRoundWon > 0)
            {
                mapStats2.TPistolRoundsLost += 1;
                mapStats1.TPistolRoundsWins += 1;   
            }
            else
            {
                mapStats1.TPistolRoundsLost += 1;
                mapStats2.TPistolRoundsWins += 1;
            }
            mapStats1.FK_GeneralStatsId = (Guid)match.Teams[0].FK_GeneralStatsId;
            mapStats1.FK_MapName = match.Map.Name;
            mapStats1.TotalRoundsPlayed = match.TeamMatchStats.CTRoundsPlayed + match.TeamMatchStats.TRoundsPlayed;
            mapStats1.CtRoundsPlayed += match.TeamMatchStats.CTRoundsPlayed;
            mapStats1.CtPistolRoundsPlayed++;            
            mapStats1.TRoundsPlayed += match.TeamMatchStats.TRoundsPlayed;
            mapStats1.TPistolRoundsPlayed++;
            match.TeamMatchStats.FK_TeamId = (Guid)match.Teams[0].Id;
            _context.Update(mapStats1); //update Mapstats for the team[0]
            _context.Update(generalStats1);
            _context.Update(match.TeamMatchStats);


            mapStats2.TotalRoundsPlayed = mapStats1.TotalRoundsPlayed;
            mapStats2.CtRoundsPlayed += mapStats1.TRoundsPlayed;
            mapStats2.CtPistolRoundsPlayed++;
            

            return true;
        }



    }
}
