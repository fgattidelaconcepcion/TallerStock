using Microsoft.EntityFrameworkCore;
using TallerStockAPI.Models;

namespace TallerStockAPI.Data
{
    public class TallerContext : DbContext
    {
        public TallerContext(DbContextOptions<TallerContext> options)
            : base(options)
        {
        }

        public DbSet<Articulo> Articulos { get; set; }

        public DbSet<MovimientoStock> MovimientosStock { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entradas = ChangeTracker.Entries<Articulo>();

            foreach (var entrada in entradas)
            {
                if (entrada.State == EntityState.Added)
                {
                    entrada.Entity.FechaAlta = DateTime.UtcNow;
                }

              
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
