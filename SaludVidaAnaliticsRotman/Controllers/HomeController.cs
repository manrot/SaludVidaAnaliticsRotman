using Microsoft.AspNetCore.Mvc;
using SaludVidaAnaliticsRotman.Models;
using System.Diagnostics;

namespace SaludVidaAnaliticsRotman.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Home Controller inicializado");
            try {
                var val = 1;
                var i = val / 0;
            }
            catch (Exception ex) {
                _logger.LogError("exception throw...");
            }
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