using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MN_SO_APS_PROJECT.Areas.Identity.Data;
using MN_SO_APS_PROJECT.Models;
using System.Diagnostics;

namespace MN_SO_APS_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            string id = _userManager.GetUserId(User);
            ApplicationUser? user = _db.Users.ToList().Find(u => u.Id == id);

            ViewBag.User = user;
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}