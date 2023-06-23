using ClassLibrary2.Reposiotory;
using ClassLibrary2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository empser;
        public HomeController(ILogger<HomeController> logger, IEmployeeRepository et)
        {
            _logger = logger;
            empser = et;
        }

        public IActionResult Index()
        {
            empser.GetAllEmployees();
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