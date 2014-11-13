using MemeCollection.Domain.Entities;
using System.Data.Entity;

namespace MemeCollection.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Meme> Memes { get; set; }
    }
}
