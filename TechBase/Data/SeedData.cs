using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechBase.Models;
using System;
using System.Linq;

namespace TechBase.Data
{
    public static class SeedData
    {
        public static void Inicializar(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Si ya hay productos, no hacer nada
                if (context.Productos.Any())
                {
                    return;
                }

                // Categorías
                var categoria1 = new Categoria { Nombre = "Electrónica" };
                var categoria2 = new Categoria { Nombre = "Hogar" };

                context.Categorias.AddRange(categoria1, categoria2);
                context.SaveChanges();

                // Productos
                context.Productos.AddRange(
                    new Producto
                    {
                        Nombre = "Teclado mecánico",
                        Descripcion = "Teclado RGB",
                        Precio = 59.99m,
                        Stock = 10,
                        IdCategoria = categoria1.IdCategoria
                    },
                    new Producto
                    {
                        Nombre = "Ratón gaming",
                        Descripcion = "Alta precisión",
                        Precio = 29.99m,
                        Stock = 15,
                        IdCategoria = categoria1.IdCategoria
                    },
                    new Producto
                    {
                        Nombre = "Lámpara LED",
                        Descripcion = "Luz cálida",
                        Precio = 19.99m,
                        Stock = 20,
                        IdCategoria = categoria2.IdCategoria
                    }
                );

                // Estados de pedido
                context.EstadosPedido.AddRange(
                    new EstadoPedido { Nombre = "En almacén" },
                    new EstadoPedido { Nombre = "En camino" },
                    new EstadoPedido { Nombre = "Entregado" },
                    new EstadoPedido { Nombre = "Cancelado" }
                );

                context.SaveChanges();
            }
        }
    }
}