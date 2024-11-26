using System.Diagnostics;
using Maris_Sorana_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Maris_Sorana_Lab2.Data;
using Maris_Sorana_Lab2.Models.LibraryViewModels;
namespace Maris_Sorana_Lab2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryContext _context;
        public HomeController(LibraryContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<ActionResult> Statistics()
        {
            IQueryable<OrderGroup> data = from order in _context.Order
                                          group order by order.OrderDate into dateGroup
                                          select new OrderGroup()
                                          {
                                              OrderDate = dateGroup.Key,
                                              BookCount = dateGroup.Count()
                                          };
            return View(await data.AsNoTracking().ToListAsync());
        }
        public IActionResult Index()
        {
            return View();
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
