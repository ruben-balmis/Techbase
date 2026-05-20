using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechBase.Models;
using Microsoft.EntityFrameworkCore;
using TechBase.Data;

namespace TechBase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var destacados = await _context.Productos
                .Include(p => p.Categoria)
                .Take(4)
                .ToListAsync();

            return View(destacados);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
