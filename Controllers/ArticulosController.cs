using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerStockAPI.Data;
using TallerStockAPI.Models;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
=======
>>>>>>> 44c94335b00e41c62c32e5ec41e37f1a0a3af098

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

<<<<<<< HEAD
=======
            // Verificamos si existe un artículo con el mismo nombre (case insensitive)
>>>>>>> 44c94335b00e41c62c32e5ec41e37f1a0a3af098
            var articuloExistente = await _context.Articulos
                .FirstOrDefaultAsync(a => a.Nombre.ToLower() == articulo.Nombre.ToLower());

            if (articuloExistente != null)
            {
<<<<<<< HEAD
                articuloExistente.Stock += articulo.Stock;

                _context.Entry(articuloExistente).State = EntityState.Modified;

                // Registrar movimiento ingreso por stock agregado
                var movimiento = new MovimientoStock
                {
                    ArticuloId = articuloExistente.Id,
                    Cantidad = articulo.Stock,
                    TipoMovimiento = "Ingreso",
                    Comentario = "Stock agregado a artículo existente"
                };
                _context.MovimientosStock.Add(movimiento);

=======
                // Si existe, aumentamos el stock
                articuloExistente.Stock += articulo.Stock;
                // Podemos también actualizar la categoría si querés, pero generalmente no se cambia aquí
                // articuloExistente.Categoria = articulo.Categoria;

                _context.Entry(articuloExistente).State = EntityState.Modified;

>>>>>>> 44c94335b00e41c62c32e5ec41e37f1a0a3af098
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Articulos.Any(e => e.Id == articuloExistente.Id))
                        return NotFound();
                    else
                        throw;
                }

<<<<<<< HEAD
                return NoContent();
            }

            // Nuevo artículo
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();

            // Registrar movimiento ingreso por nuevo artículo
            var nuevoMovimiento = new MovimientoStock
            {
                ArticuloId = articulo.Id,
                Cantidad = articulo.Stock,
                TipoMovimiento = "Ingreso",
                Comentario = "Alta de nuevo artículo"
            };
            _context.MovimientosStock.Add(nuevoMovimiento);

            await _context.SaveChangesAsync();

=======
                // Devolvemos NoContent porque es una actualización, o bien CreatedAtAction si preferís
                return NoContent();
            }

            // Si no existe el artículo, lo agregamos normalmente
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();

>>>>>>> 44c94335b00e41c62c32e5ec41e37f1a0a3af098
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
<<<<<<< HEAD

        // GET: api/articulos/5/movimientos
        [HttpGet("{id}/movimientos")]
        public async Task<ActionResult<IEnumerable<MovimientoStock>>> GetMovimientos(int id)
        {
            var movimientos = await _context.MovimientosStock
                .Where(m => m.ArticuloId == id)
                .OrderByDescending(m => m.FechaMovimiento)
                .ToListAsync();

            return movimientos;
        }
=======
>>>>>>> 44c94335b00e41c62c32e5ec41e37f1a0a3af098
    }
}
