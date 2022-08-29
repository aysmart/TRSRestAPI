using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TRSRestAPI.Models;

namespace TRSRestAPI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBModelsContext _db;
        public HomeController(ILogger<HomeController> logger, DBModelsContext db)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var TravelReqs = _db.TravelRequests;
            return Json(TravelReqs);
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