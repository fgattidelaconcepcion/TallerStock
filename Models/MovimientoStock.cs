using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerStockAPI.Models
{
    public class MovimientoStock
    {
        public int Id { get; set; }

        [Required]
        public int ArticuloId { get; set; }

        [ForeignKey("ArticuloId")]
        public Articulo Articulo { get; set; } = null!;

        public DateTime FechaMovimiento { get; set; } = DateTime.UtcNow;

        [Required]
        public int Cantidad { get; set; }  // + ingreso, - egreso

        [Required]
        [MaxLength(50)]
        public string TipoMovimiento { get; set; } = string.Empty; // Ej: "Compra", "Uso", "Ajuste"

        [MaxLength(200)]
        public string? Comentario { get; set; }
    }
}
