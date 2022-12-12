using Microsoft.EntityFrameworkCore;

namespace iTortaniServer.Models.Spese
{
    public class SpeseContext : DbContext
    {
        public SpeseContext(DbContextOptions<SpeseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Spese> Spese { get; set; }
    }
}
