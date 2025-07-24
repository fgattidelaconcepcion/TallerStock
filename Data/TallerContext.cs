using Microsoft.EntityFrameworkCore;
using TallerStockAPI.Models;

namespace TallerStockAPI.Data
{
    public class TallerContext : DbContext
    {
        public TallerContext(DbContextOptions<TallerContext> options) : base(options) { }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<MovimientoStock> MovimientosStock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>()
                .HasIndex(a => new { a.Nombre, a.Tamano })
                .IsUnique();
        }
    }
}
