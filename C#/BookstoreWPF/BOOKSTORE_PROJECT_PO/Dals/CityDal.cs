using BOOKSTORE_PROJECT_PO.Dal_Models;
using BOOKSTORE_PROJECT_PO.Models;
using System.Collections.Generic;
using System.Linq;

namespace BOOKSTORE_PROJECT_PO
{
    /// <summary>
    /// Data source for city
    /// </summary>
    public class CityDal
    {
        private BookstoreDBEntities db = new BookstoreDBEntities();

        /// <summary>
        /// Fetching city information to include in a combobox
        /// </summary>
        public IList<CityDalModelForSelector> getCityList =>
            db.Cities.Select(
                city => new CityDalModelForSelector
                {
                    ID = city.ID,
                    Name = city.CityName
                }).ToList();

        /// <summary>
        /// Fetching specific information about a city to include in a table
        /// </summary>
        public IList<CityDalModel> getCityNameList =>
            db.Cities.Select(
                city => new CityDalModel
                {
                    City = city.CityName
                }).ToList();

        /// <summary>
        /// Function to add a new city based on city parameter
        /// </summary>
        /// <param name="city">City name</param>
        public void Add(string city)
        {
            var newCity = new Cities()
            {
                CityName = city,
            };

            db.Cities.Add(newCity);
            db.SaveChanges();
        }

        /// <summary>
        /// Function to delete a specific city identified by city parameter
        /// </summary>
        /// <param name="city">City name</param>
        public void Delete(string city)
        {
            var cityToDelete = db.Cities
              .Where(cty => cty.CityName == city)
              .Select(cty => cty)
              .FirstOrDefault();
            db.Customers
               .Where(cus => cus.CityId == cityToDelete.ID)
               .ToList()
               .ForEach(x =>
               {
                   x.CityId = null;
               });

            db.Cities.Remove(cityToDelete);
            db.SaveChanges();
        }

        /// <summary>
        /// Function to get a city ID based on city parameter
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <returns>ID as int</returns>
        internal int GetCityID(string cityName) => db.Cities.Where(city => city.CityName == cityName).Select(city => city.ID).FirstOrDefault();
    }
}
