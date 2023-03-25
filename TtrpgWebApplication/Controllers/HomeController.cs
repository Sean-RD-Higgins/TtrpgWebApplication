using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TtrpgLibrary.Repos;
using TtrpgWebApplication.Models;

namespace TtrpgWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        const string databaseName = "epiz_32554537_db";
        const string portNumber = "3306";
        const string USER = "admin";
        const string PASS = "admin";
        const string connectionstring = "server=localhost;user=" + USER + ";database=" + databaseName + ";port=" + portNumber + ";password=" + PASS;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new GameSelectPageModel(new TtrpgRepository(connectionstring).GetTtrpgGameList()));
        }
        
        public IActionResult Create(int id)
        {
            _logger.LogInformation("Accessed id [id]", id);
            return View(new SheetCreatePageModel(new TtrpgRepository(connectionstring).GetTtrpg(id)));
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