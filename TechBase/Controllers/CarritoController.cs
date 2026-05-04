using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TechBase.Data;
using TechBase.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


public class CarritoController : Controller
{
    private const string SessionKey = "Carrito";
    private readonly ApplicationDbContext _context;

    public CarritoController(ApplicationDbContext context)
    {
        _context = context;
    }

    private List<CarritoItem> ObtenerCarrito()
    {
        var carritoJson = HttpContext.Session.GetString(SessionKey);

        if (carritoJson == null)
            return new List<CarritoItem>();

        return JsonSerializer.Deserialize<List<CarritoItem>>(carritoJson);
    }

    private void GuardarCarrito(List<CarritoItem> carrito)
    {
        var carritoJson = JsonSerializer.Serialize(carrito);
        HttpContext.Session.SetString(SessionKey, carritoJson);
    }

    public IActionResult Index()
    {
        var carrito = ObtenerCarrito();
        return View(carrito);
    }
    public IActionResult Agregar(int id, string nombre, decimal precio)
    {
        var carrito = ObtenerCarrito();

        var item = carrito.FirstOrDefault(p => p.IdProducto == id);

        if (item != null)
        {
            item.Cantidad++;
        }
        else
        {
            carrito.Add(new CarritoItem
            {
                IdProducto = id,
                Nombre = nombre,
                Precio = precio,
                Cantidad = 1
            });
        }

        GuardarCarrito(carrito);

        return RedirectToAction("Index");
    }
    public IActionResult Eliminar(int id)
    {
        var carrito = ObtenerCarrito();

        var item = carrito.FirstOrDefault(p => p.IdProducto == id);

        if (item != null)
        {
            carrito.Remove(item);
        }

        GuardarCarrito(carrito);

        return RedirectToAction("Index");
    }
    public IActionResult Sumar(int id)
    {
        var carrito = ObtenerCarrito();

        var item = carrito.FirstOrDefault(p => p.IdProducto == id);

        if (item != null)
        {
            item.Cantidad++;
        }

        GuardarCarrito(carrito);

        return RedirectToAction("Index");
    }
    public IActionResult Restar(int id)
    {
        var carrito = ObtenerCarrito();

        var item = carrito.FirstOrDefault(p => p.IdProducto == id);

        if (item != null)
        {
            item.Cantidad--;

            if (item.Cantidad <= 0)
            {
                carrito.Remove(item);
            }
        }

        GuardarCarrito(carrito);

        return RedirectToAction("Index");
    }
    [Authorize]
    public IActionResult Confirmar()
    {
        var carrito = ObtenerCarrito();

        if (!carrito.Any())
            return RedirectToAction("Index");
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var pedido = new Pedido
        {
            Fecha = DateTime.Now,
            Total = carrito.Sum(x => x.Precio * x.Cantidad),
            UserId = userId, 
            IdEstado = 1 
        };

        _context.Pedidos.Add(pedido);
        _context.SaveChanges();

        foreach (var item in carrito)
        {
            var detalle = new DetallePedido
            {
                IdPedido = pedido.IdPedido,
                IdProducto = item.IdProducto,
                Cantidad = item.Cantidad,
                PrecioUnitario = item.Precio
            };

            _context.DetallesPedido.Add(detalle);
        }

        _context.SaveChanges();
        HttpContext.Session.Remove("Carrito");
        return RedirectToAction("Index", "Productos");
    }
    [Authorize]
    public IActionResult MisPedidos()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var pedidos = _context.Pedidos
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.Fecha)
            .ToList();

        return View(pedidos);
    }
    [Authorize]
    public IActionResult DetallePedido(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var pedido = _context.Pedidos
            .Where(p => p.IdPedido == id && p.UserId == userId)
            .Include(p => p.Estado)
            .FirstOrDefault();

        if (pedido == null)
            return NotFound();

        var detalles = _context.DetallesPedido
            .Where(d => d.IdPedido == id)
            .Include(d => d.Producto)
            .ToList();

        ViewBag.Pedido = pedido;

        return View(detalles);
    }
}
