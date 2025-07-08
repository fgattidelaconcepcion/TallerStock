using System.ComponentModel.DataAnnotations;

namespace TallerStockAPI.Models
{
    public class Articulo
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        public int Stock { get; set; }

        [MaxLength(100)]
        public string Categoria { get; set; }
    }
}
