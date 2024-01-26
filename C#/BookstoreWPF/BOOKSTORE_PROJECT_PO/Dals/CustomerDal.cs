using BOOKSTORE_PROJECT_PO.Dal_Models;
using BOOKSTORE_PROJECT_PO.Dal_Models.CustomerModels;
using BOOKSTORE_PROJECT_PO.Models;
using System.Collections.Generic;
using System.Linq;

namespace BOOKSTORE_PROJECT_PO.Dals
{
    /// <summary>
    /// Data source for customer
    /// </summary>
    public class CustomerDal
    {
        private BookstoreDBEntities db = new BookstoreDBEntities();

        /// <summary>
        /// Fetching specific information about a customer to include in a table
        /// </summary>
        public IList<CustomerDalModel> getCustomerList =>
            db.Customers.Select(
                customer => new CustomerDalModel
                {
                    Name = customer.FirstName + " " + customer.LastName,
                    Email = customer.Email,
                    City = customer.Cities.CityName
                }).ToList();

        /// <summary>
        /// Fetching customer information to include in a combobox
        /// </summary>
        public IList<CustomerDalModelForSelector> getCustomerForSelecorList =>
            db.Customers.Select(
                customer => new CustomerDalModelForSelector
                {
                    ID = customer.ID,
                    Name = customer.FirstName + " " + customer.LastName,
                }).ToList();

        /// <summary>
        /// Function to add a new city based on firstName, lastName, email, cityId params
        /// </summary>
        /// <param name="firstName">Customer name</param>
        /// <param name="lastName">Customer last name</param>
        /// <param name="email">Customer email</param>
        /// <param name="cityId">City identified by ID</param>
        public void Add(string firstName, string lastName, string email, int cityId)
        {
            var newCustomer = new Customers()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                CityId = cityId,
            };

            db.Customers.Add(newCustomer);
            db.SaveChanges();
        }

        /// <summary>
        /// Function to update customer email
        /// </summary>
        /// <param name="email">Email to indentify customer</param>
        /// <param name="emailToUpdate">A new email</param>
        /// <param name="cityId">A new city identified by ID</param>
        public void Update(string email, string emailToUpdate, int cityId)
        {
            var customerToUpdate = db.Customers
                .Where(cus => cus.Email == email)
                .Select(cus => cus)
                .Single();

            if (customerToUpdate != null)
            {
                customerToUpdate.Email = emailToUpdate;
                customerToUpdate.CityId = cityId;
            }

            db.SaveChanges();
        }

        /// <summary>
        /// Function to delete a specific customer identified by email parameter
        /// </summary>
        /// <param name="email">Customer email</param>
        public void Delete(string email)
        {
            var customerToDelete =
                db.Customers
                .Where(cus => cus.Email == email)
                .Select(cus => cus)
                .Single();
            db.Books
                .Where(book => book.CustomerId == customerToDelete.ID)
                .ToList()
                .ForEach(x =>
                {
                    x.CustomerId = null;
                });

            db.Customers.Remove(customerToDelete);
            db.SaveChanges();
        }
    }
}