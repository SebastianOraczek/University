using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MN_SO_APS_PROJECT.Areas.Identity.Data;
using MN_SO_APS_PROJECT.Models;

namespace MN_SO_APS_PROJECT.Controllers
{

    [Authorize(Roles = "admin")]
    public class CountryController : Controller
    {
        ApplicationDbContext _db;

        public CountryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryModel city)
        {
            try
            {
                CountryModel newCountry = new CountryModel { Id = city.Id, CountryName = city.CountryName };


                _db.Coutry.Add(newCountry);
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
            List<CountryModel> countries = _db.Coutry.ToList();

            return View(countries);
        }
    }
}
