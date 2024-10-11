using Microsoft.EntityFrameworkCore;

namespace API_Ferramenta_test.Models
{
    public class FerramentaContext : DbContext
    {
        public FerramentaContext(DbContextOptions<FerramentaContext> options) : base(options) { }

        public DbSet<Reparto> Reparto { get; set; }
        public DbSet<Prodotto> Prodotto { get; set; }

    }
}
