using Microsoft.EntityFrameworkCore;
using TallerStockAPI.Models;

namespace TallerStockAPI.Data
{
    public class TallerContext : DbContext
    {
        public TallerContext(DbContextOptions<TallerContext> options) : base(options) { }

        public DbSet<Articulo> Articulos { get; set; }
    }
}
