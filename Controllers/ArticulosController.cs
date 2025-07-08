using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerStockAPI.Data;
using TallerStockAPI.Models;

namespace TallerStockAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private readonly TallerContext _context;

        public ArticulosController(TallerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulos()
        {
            return await _context.Articulos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Articulo>> CrearArticulo(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArticulos), new { id = articulo.Id }, articulo);
        }
    }
}
