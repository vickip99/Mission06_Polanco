using Microsoft.EntityFrameworkCore;

namespace Mission06_Polanco.Models
{
    public class FilmCollectionContext : DbContext
    {
        public FilmCollectionContext(DbContextOptions<FilmCollectionContext> options) : base (options) //Constructor to set up options
        {
        }
        public DbSet<Collection> Movies { get; set; }

        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
