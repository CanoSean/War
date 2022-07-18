using War.Data;
using War.DataAccess.Interfaces;
using War.Domain;

namespace War.DataAccess
{
    public class DefaultRepository : IEntityRepository
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<Card> GetAllCards()
        {
            return _context.Cards;
        }
    }
}
