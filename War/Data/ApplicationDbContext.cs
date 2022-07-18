using Microsoft.EntityFrameworkCore;
using War.Domain;

namespace War.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Card> Cards { get; set; }

    }
}
