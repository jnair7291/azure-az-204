using az204v1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using az204v1.DBService;

namespace az204v1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userService;
        public HomeController(ILogger<HomeController> logger , UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetUser();
            return View(users);
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