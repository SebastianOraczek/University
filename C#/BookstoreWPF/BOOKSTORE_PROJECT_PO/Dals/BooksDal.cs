using BOOKSTORE_PROJECT_PO.Dal_Models;
using BOOKSTORE_PROJECT_PO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BOOKSTORE_PROJECT_PO.Dals
{
    /// <summary>
    /// Data source for book
    /// </summary>
    public class BooksDal
    {
        private BookstoreDBEntities db = new BookstoreDBEntities();

        /// <summary>
        /// Fetching specific information about a book to include in a table
        /// </summary>
        public List<BookDalModel> getBooksList =>
            db.Books.Select(
                book => new BookDalModel
                {
                    Title = book.Title,
                    PublishedYear = book.PublishedYear.Year,
                    Author = book.Authors.FirstName + " " + book.Authors.LastName,
                    Quantity = book.Quantity,
                    Status = book.Status.StatusName,
                    LastCustomer = book.Customers.FirstName + " " + book.Customers.LastName,
                }).ToList();

        /// <summary>
        /// Function to add a new book based on title, date qtl(quality), authorId, statusId and lastCustomerId params
        /// </summary>
        /// <param name="title">Book title</param>
        /// <param name="date">Published year</param>
        /// <param name="qtl">Quality</param>
        /// <param name="authorId">Author identified by ID</param>
        /// <param name="statusId">Status identified by ID</param>
        /// <param name="lastCustomerId">Customer identified by ID</param>
        public void Add(string title, DateTime date, int qtl, int authorId, int statusId, int lastCustomerId)
        {
            var newBook = new Books()
            {
                Title = title,
                PublishedYear = date,
                AuthorId = authorId,
                StatusId = statusId,
                CustomerId = lastCustomerId,
                Quantity = qtl,
            };

            db.Books.Add(newBook);
            db.SaveChanges();
        }

        /// <summary>
        /// Function to delete a specific book identified by title parameter
        /// </summary>
        /// <param name="title">Book title</param>
        public void Delete(string title)
        {
            var bookToDelete = db.Books
                .Where(book => book.Title == title)
                .Select(book => book)
                .FirstOrDefault();

            db.Books.Remove(bookToDelete);
            db.SaveChanges();
        }
    }
}
