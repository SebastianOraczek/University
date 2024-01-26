using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MN_SO_APS_PROJECT.Areas.Identity.Data;
using MN_SO_APS_PROJECT.Models;

namespace MN_SO_APS_PROJECT.Controllers
{
    [Authorize(Roles = "admin")]
    public class CityController : Controller
    {
        ApplicationDbContext _db;

        public CityController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityModel city)
        {
            try
            {
                CityModel newCity = new CityModel { Id = city.Id, CityName = city.CityName };


                _db.City.Add(newCity);
                _db.SaveChanges();

                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View(nameof(List));
            }
        }

        public ActionResult List()
        {
            List<CityModel> cities = _db.City.ToList();

            return View(cities);
        }
    }
}
