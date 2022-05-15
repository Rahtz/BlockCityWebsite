using Microsoft.EntityFrameworkCore;

namespace BlockCity.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Stat> Stats { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        internal object GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
