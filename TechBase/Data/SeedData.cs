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
                if (context.Productos.Any())
                {
                    return;
                }

                // CATEGORÍAS
                context.Categorias.AddRange(
                    new Categoria { Nombre = "Tarjetas Gráficas" },
                    new Categoria { Nombre = "Procesadores" },
                    new Categoria { Nombre = "Placas Base" },
                    new Categoria { Nombre = "Discos Duros" },
                    new Categoria { Nombre = "Fuentes de Alimentación" }
                );

                context.SaveChanges();
                var categorias = context.Categorias.ToList();

                // Productos
                context.Productos.AddRange(

                    // TARJETAS GRÁFICAS
                    new Producto { Nombre = "Gigabyte GeForce RTX 4060 8GB GDDR6", Precio = 530m, Stock = 10, IdCategoria = categorias.First(c => c.Nombre == "Tarjetas Gráficas").IdCategoria, ImagenUrl = "rtx4060.jpg" },
                    new Producto { Nombre = "MSI GeForce RTX 5060 Ti Ventus 8GB GDDR7", Precio = 359m, Stock = 10, IdCategoria = categorias.First(c => c.Nombre == "Tarjetas Gráficas").IdCategoria, ImagenUrl = "rtx5060.jpg" },
                    new Producto { Nombre = "Gigabyte GeForce RTX 3080 Gaming OC 12GB", Precio = 479m, Stock = 8, IdCategoria = categorias.First(c => c.Nombre == "Tarjetas Gráficas").IdCategoria, ImagenUrl = "rtx3080.jpg" },
                    new Producto { Nombre = "Asus Dual GeForce RTX 3060 OC 12GB", Precio = 510m, Stock = 10, IdCategoria = categorias.First(c => c.Nombre == "Tarjetas Gráficas").IdCategoria, ImagenUrl = "rtx3060.jpg" },
                    new Producto { Nombre = "MSI GeForce RTX 5070 Ti Gaming Trio 16GB", Precio = 1079m, Stock = 5, IdCategoria = categorias.First(c => c.Nombre == "Tarjetas Gráficas").IdCategoria, ImagenUrl = "rtx5070.jpg" },

                    // PROCESADORES
                    new Producto { Nombre = "AMD Ryzen 7 9800X3D", Precio = 424m, Stock = 10, IdCategoria = categorias.First(c => c.Nombre == "Procesadores").IdCategoria, ImagenUrl = "7-9800X3D.jpg" },
                    new Producto { Nombre = "AMD Ryzen 7 5800X", Precio = 209m, Stock = 10, IdCategoria = categorias.First(c => c.Nombre == "Procesadores").IdCategoria, ImagenUrl = "7-5800X.jpg" },
                    new Producto { Nombre = "Intel Core i7-12700", Precio = 340m, Stock = 10, IdCategoria = categorias.First(c => c.Nombre == "Procesadores").IdCategoria, ImagenUrl = "i7-12700.jpg" },
                    new Producto { Nombre = "AMD Ryzen 5 5500", Precio = 79m, Stock = 15, IdCategoria = categorias.First(c => c.Nombre == "Procesadores").IdCategoria, ImagenUrl = "5-5500.jpg" },
                    new Producto { Nombre = "AMD Ryzen 5 9600X", Precio = 192m, Stock = 12, IdCategoria = categorias.First(c => c.Nombre == "Procesadores").IdCategoria, ImagenUrl = "5-9600X.jpg" },

                    // PLACAS BASE
                    new Producto { Nombre = "MSI B850 Gaming Plus WiFi", Precio = 211m, Stock = 10, IdCategoria = categorias.First(c => c.Nombre == "Placas Base").IdCategoria, ImagenUrl = "MSI-B850.jpg" },
                    new Producto { Nombre = "MSI MPG B550 Gaming Plus", Precio = 119m, Stock = 10, IdCategoria = categorias.First(c => c.Nombre == "Placas Base").IdCategoria, ImagenUrl = "MSI-MPG-B550.jpg" },
                    new Producto { Nombre = "MSI PRO B850-S WiFi6E ATX", Precio = 144m, Stock = 10, IdCategoria = categorias.First(c => c.Nombre == "Placas Base").IdCategoria, ImagenUrl = "MSI-PRO-B850-S.jpg" },

                    // DISCOS DUROS
                    new Producto { Nombre = "Forgeon Nimbus Plus SSD 2TB NVMe", Precio = 269m, Stock = 10, IdCategoria = categorias.First(c => c.Nombre == "Discos Duros").IdCategoria, ImagenUrl = "Nimbus-2TB.jpg" },
                    new Producto { Nombre = "Kingston NV3 1TB SSD NVMe", Precio = 159m, Stock = 12, IdCategoria = categorias.First(c => c.Nombre == "Discos Duros").IdCategoria, ImagenUrl = "Kingston-1TB.jpg" },
                    new Producto { Nombre = "Samsung 990 Pro 1TB SSD NVMe", Precio = 227m, Stock = 8, IdCategoria = categorias.First(c => c.Nombre == "Discos Duros").IdCategoria, ImagenUrl = "Samsung-1TB.jpg" },
                    new Producto { Nombre = "Toshiba Canvio Basics 2TB Externo", Precio = 87m, Stock = 15, IdCategoria = categorias.First(c => c.Nombre == "Discos Duros").IdCategoria, ImagenUrl = "Toshiba-2TB.jpg" },

                    // FUENTES
                    new Producto { Nombre = "Tempest GPSU 750W V2", Precio = 33m, Stock = 15, IdCategoria = categorias.First(c => c.Nombre == "Fuentes de Alimentación").IdCategoria, ImagenUrl = "750W.jpg" },
                    new Producto { Nombre = "Forgeon Reactor 850W Platinum", Precio = 89m, Stock = 10, IdCategoria = categorias.First(c => c.Nombre == "Fuentes de Alimentación").IdCategoria, ImagenUrl = "850W.jpg" },
                    new Producto { Nombre = "Corsair RM1000e 1000W Gold", Precio = 119m, Stock = 8, IdCategoria = categorias.First(c => c.Nombre == "Fuentes de Alimentación").IdCategoria, ImagenUrl = "1000W.jpg" }

                );

                context.SaveChanges();

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