using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MN_SO_APS_PROJECT.Areas.Identity.Data;
using MN_SO_APS_PROJECT.Models;
using System.Security.Claims;

namespace MN_SO_APS_PROJECT.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Details()
        {
            string id = _userManager.GetUserId(User);
            ApplicationUser? user = _db.Users.ToList().Find(u => u.Id == id);

            CityModel city = _db.City.ToList().Find(c => c.Id == user.CityId);
            CountryModel country = _db.Coutry.ToList().Find(c => c.Id == user.CountryId);

            ViewBag.User = user;
            ViewBag.City = city;
            ViewBag.Country = country;
            ViewBag.None = '-';

            return View(ViewBag);
        }

        [AllowAnonymous]
        public IActionResult List()
        {
            List<ApplicationUser> users = _db.Users.ToList();
            return View(users);
        }
    }
}
