using System.ComponentModel.DataAnnotations;

namespace TechBase.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Producto> Productos { get; set; }
    }
}