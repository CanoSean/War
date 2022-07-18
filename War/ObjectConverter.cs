using War.Domain;
using War.Models;

namespace War
{
    public class ObjectConverter
    {
        public List<CardModel> ConvertCards(IEnumerable<Card> objCardData)
        {
            var list = new List<CardModel>();
            foreach(var card in objCardData)
            {
                var newObj = new CardModel();
                newObj.Value = card.Value;
                newObj.Rank = card.Rank;
                newObj.Suit = card.Suit;
                newObj.PlayerID = card.PlayerID;
                list.Add(newObj);
            }
            return list;
        }
    }
}
