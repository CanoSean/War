using War.DataAccess;
using War.DataAccess.Interfaces;

namespace War.Factories
{
    public class DataObjectFactory
    {
        internal IEntityRepository CreateRepository(string respository)
        {
            if (respository == "Default")
            {
                return new DefaultRepository();
            }
            if (respository == "AdoNet")
            {
                return new AdoNetRepository();
            }
            throw new Exception("No repository found");
        }
    }
}
