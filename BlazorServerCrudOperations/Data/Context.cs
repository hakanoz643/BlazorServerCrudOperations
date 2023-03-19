using Microsoft.EntityFrameworkCore;

namespace BlazorServerCrudOperations.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game() { Id=1, Name="Counter Strike", Developer="Valve",Release=DateTime.Now },
                new Game() { Id = 2, Name = "Pubg", Developer = "Tencent Game", Release = DateTime.Now.AddDays(-2) },
                new Game() { Id = 3, Name = "Valorant", Developer = "Epik Games", Release = DateTime.Now.AddDays(-10) }

            );
        }
        public DbSet<Game> Games { get; set; }
    }
}
