using System.ComponentModel.DataAnnotations;

namespace TallerStockAPI.Models
{
    public class Articulo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [MaxLength(100)]
        public string Categoria { get; set; } = string.Empty;

        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;

        [MaxLength(50)]
        [Required(ErrorMessage = "El tamaño es obligatorio.")]
        public string Tamano { get; set; } = string.Empty;
    }
}
