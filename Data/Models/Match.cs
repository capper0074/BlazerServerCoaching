using System.ComponentModel.DataAnnotations;

namespace BlazerServerCoaching.Data.Models
{
    public class Match
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public MatchType Type { get; set; }

        public string Oppenent { get; set; }

        public MatchMaps Maps { get; set; }

        public MatchStatus Status { get; set; }

        public int TSideW { get; set; }

        public int TSideL { get; set; }

        public int CTSideW { get; set; }

        public int CTSideL { get; set; }

        public bool TPistol { get; set; }

        public bool CTPistol { get; set; }
    }
}
