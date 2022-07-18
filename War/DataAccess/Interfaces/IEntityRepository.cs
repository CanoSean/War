using War.Domain;

namespace War.DataAccess.Interfaces
{
    public interface IEntityRepository : IDisposable
    {
        IEnumerable<Card> GetAllCards();
    }
}
