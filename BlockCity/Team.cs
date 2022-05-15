using System.ComponentModel.DataAnnotations;

namespace BlockCity
{
    public class Team
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string TeamName { get; set; } = string.Empty;
    }
}
