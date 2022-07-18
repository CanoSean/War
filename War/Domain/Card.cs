using System.ComponentModel.DataAnnotations;

namespace War.Domain
{
    public class Card
    {
        [Key]
        public int PlayerID { get; set; }
        public int Value { get; set; }
        public string Suit { get; set; }
        public string Rank { get; set; }

        public Card(int value, string suit, string rank)
        {
            Value = value;
            Suit = suit;
            Rank = rank;
        }
    }
}
