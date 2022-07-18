using War.DataAccess.Interfaces;
using War.Domain;

namespace War.DataAccess
{
    public class AdoNetRepository : IEntityRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Card> GetAllCards()
        {
            throw new NotImplementedException();
        }
    }
}
