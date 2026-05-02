using System.ComponentModel.DataAnnotations;

namespace TechBase.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required]
        public string Nombre { get; set; }

        // Relación: una categoría tiene muchos productos
        public List<Producto> Productos { get; set; }
    }
}