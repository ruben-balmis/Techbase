using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechBase.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }

        // FK usuario (Identity)
        public string? UserId { get; set; }

        // FK estado
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public EstadoPedido Estado { get; set; }

        public List<DetallePedido> Detalles { get; set; }
    }
}