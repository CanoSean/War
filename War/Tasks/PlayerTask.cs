using War.Data;
using War.DataAccess.Interfaces;
using War.Domain;
using War.Models;

namespace War.Tasks
{
    public class PlayerTask
    {
        private ObjectConverter _converter = new ObjectConverter();
        public List<CardModel> GetAllCards(IEntityRepository repository)
        {
            IEnumerable<Card> objCardData = repository.GetAllCards();
            return _converter.ConvertCards(objCardData);
        }
    }
}
