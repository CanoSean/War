using System.ComponentModel.DataAnnotations;

namespace War.Domain
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        public int Wins { get; set; }

        [Required]
        public string Username { get; set; }

        public string Enemy { get; set; }

        public int Loses { get; set; }

        public int GamePlayed { get; set; }

        public int NumberOfMove { get; set; }

        public Player(int wins, string username, int loses, int gamePlayed, int numberOfMove, string enemy)
        {
            Wins = wins;
            Username = username;
            Loses = loses;
            GamePlayed = gamePlayed;
            NumberOfMove = numberOfMove;
            Enemy = enemy;
        }

        public Player()
        {
        }
    }
}
