using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechBase.Data;
using Microsoft.AspNetCore.Authorization;


namespace TechBase.Controllers
{

    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? categoriaId, string buscar)
        {
            var productos = _context.Productos
                .Include(p => p.Categoria)
                .AsQueryable();

            if (categoriaId != null)
            {
                productos = productos.Where(p => p.IdCategoria == categoriaId);
            }

            if (!string.IsNullOrEmpty(buscar))
            {
                productos = productos.Where(p =>
                    p.Nombre.Contains(buscar));
            }

            ViewBag.Categorias = await _context.Categorias.ToListAsync();

            return View(await productos.ToListAsync());
        }

        public async Task<IActionResult> Detalle(int id)
        {
            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.IdProducto == id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }
    }
}