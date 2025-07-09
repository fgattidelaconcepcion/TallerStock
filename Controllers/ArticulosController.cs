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

        // GET: api/articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulos(
            string? nombre = null,
            string? categoria = null,
            int page = 1,
            int pageSize = 10)
        {
            var query = _context.Articulos.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(a => a.Nombre.Contains(nombre));

            if (!string.IsNullOrEmpty(categoria))
                query = query.Where(a => a.Categoria.Contains(categoria));

            var total = await query.CountAsync();
            var articulos = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Encabezado de paginación 
            Response.Headers.Add("X-Total-Count", total.ToString());

            return articulos;
        }

        // GET: api/articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo == null)
                return NotFound();

            return articulo;
        }

        // POST: api/articulos
        [HttpPost]
        public async Task<ActionResult<Articulo>> CrearArticulo(Articulo articulo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArticulo), new { id = articulo.Id }, articulo);
        }

        // PUT: api/articulos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarArticulo(int id, Articulo articulo)
        {
            if (id != articulo.Id)
                return BadRequest("El ID del artículo no coincide.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Articulos.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo == null)
                return NotFound();

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
