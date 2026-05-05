using System.ComponentModel.DataAnnotations;

namespace TechBase.Models
{
    public class EstadoPedido
    {
        [Key]
        public int IdEstado { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}