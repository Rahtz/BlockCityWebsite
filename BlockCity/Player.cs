using System.ComponentModel.DataAnnotations;

namespace BlockCity
{
    public class Player
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string PlayerName { get; set; } = string.Empty;
    }
}
