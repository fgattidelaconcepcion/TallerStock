using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerStockAPI.Data;
using TallerStockAPI.Models;

namespace TallerStockAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientosStockController : ControllerBase
    {
        private readonly TallerContext _context;

        public MovimientosStockController(TallerContext context)
        {
            _context = context;
        }

        // GET: api/movimientosstock/{articuloId}
        [HttpGet("{articuloId}")]
        public async Task<ActionResult<IEnumerable<MovimientoStock>>> GetMovimientosPorArticulo(int articuloId)
        {
            var movimientos = await _context.MovimientosStock
                .Where(m => m.ArticuloId == articuloId)
                .OrderByDescending(m => m.FechaMovimiento)
                .ToListAsync();

            return movimientos;
        }

        // POST: api/movimientosstock
        [HttpPost]
        public async Task<IActionResult> CrearMovimiento(MovimientoStock movimiento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var articulo = await _context.Articulos.FindAsync(movimiento.ArticuloId);
            if (articulo == null)
                return NotFound("Artículo no encontrado.");

            int nuevoStock = articulo.Stock + movimiento.Cantidad;

            if (nuevoStock < 0)
                return BadRequest("No se puede reducir el stock por debajo de cero.");

            articulo.Stock = nuevoStock;

            _context.MovimientosStock.Add(movimiento);
            _context.Entry(articulo).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovimientosPorArticulo), new { articuloId = movimiento.ArticuloId }, movimiento);
        }
    }
}