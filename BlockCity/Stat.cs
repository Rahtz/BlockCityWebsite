using System.ComponentModel.DataAnnotations;

namespace BlockCity
{
    public class Stat
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public Player? Player { get; set; }

        public int TeamId { get; set; }

        public Team? Team { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime YourDate { get; set; }

        public int Points { get; set; }

        public int Rebounds { get; set; }

        public int Assists { get; set; }

        public int Steals { get; set; }

        public int Blocks { get; set; }

        public int FeildGoalsAttempted { get; set; }

        public int FeildGoalsMade { get; set; }

        public int ThreePointersAttempted { get; set; }

        public int ThreePointerMade { get; set; }

        public int FreeThrowsAttempted { get; set; }

        public int FreeThrowsMade { get; set; }

        public int GamesPlayed { get; set; } = 1;

        internal IEnumerable<object> GroupBy(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
