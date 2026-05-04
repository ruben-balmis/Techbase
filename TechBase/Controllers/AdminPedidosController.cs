using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechBase.Data;

[Authorize(Roles = "Admin")]
public class AdminPedidosController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminPedidosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var pedidos = _context.Pedidos
            .Include(p => p.Estado)
            .Include(p => p.User)
            .OrderByDescending(p => p.Fecha)
            .ToList();

        return View(pedidos);
    }
    public IActionResult EditarEstado(int id)
    {
        var pedido = _context.Pedidos.Find(id);

        if (pedido == null)
            return NotFound();

        ViewBag.Estados = _context.EstadosPedido.ToList();

        return View(pedido);
    }
    [HttpPost]
    public IActionResult EditarEstado(int id, int idEstado)
    {
        var pedido = _context.Pedidos.Find(id);

        if (pedido == null)
            return NotFound();

        pedido.IdEstado = idEstado;

        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    public IActionResult Detalle(int id)
    {
        var pedido = _context.Pedidos
            .Include(p => p.Estado)
            .Include(p => p.User)
            .FirstOrDefault(p => p.IdPedido == id);

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