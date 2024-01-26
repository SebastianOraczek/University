using BOOKSTORE_PROJECT_PO.Dal_Models;
using BOOKSTORE_PROJECT_PO.Dal_Models.AuthorModels;
using BOOKSTORE_PROJECT_PO.Models;
using System.Collections.Generic;
using System.Linq;

namespace BOOKSTORE_PROJECT_PO.Dals
{
    /// <summary>
    /// Data source for author
    /// </summary>
    public class AuthorDal
    {
        private BookstoreDBEntities db = new BookstoreDBEntities();

        /// <summary>
        /// Fetching author information to include in a combobox
        /// </summary>
        public IList<AuthorDalModelForSelector> getAuthorList =>
            db.Authors.Select(
                author => new AuthorDalModelForSelector
                {
                    ID = author.ID,
                    Name = author.FirstName + " " + author.LastName
                }).ToList();

        /// <summary>
        /// Fetching specific information about a author to include in a table
        /// </summary>
        public IList<AuthorDalModel> getAuthorNameList =>
            db.Authors.Select(
                author => new AuthorDalModel
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                }).ToList();

        /// <summary>
        /// Function to add a new autor based on firstName and lastName params
        /// </summary>
        /// <param name="firstName">Author first name</param>
        /// <param name="lastName">Author last name</param>
        public void Add(string firstName, string lastName)
        {
            var newAuthor = new Authors()
            {
                FirstName = firstName,
                LastName = lastName
            };

            db.Authors.Add(newAuthor);
            db.SaveChanges();
        }

        /// <summary>
        /// Function to delete a specific author identified by lastName parameter
        /// </summary>
        /// <param name="lastName">Author last name</param>
        public void Delete(string lastName)
        {
            var authorToDelete =
                db.Authors
                .Where(auth => auth.LastName == lastName)
                .Select(aut => aut)
                .Single();
            db.Books
               .Where(book => book.AuthorId == authorToDelete.ID)
               .ToList()
               .ForEach(x =>
               {
                   x.AuthorId = null;
               });

            db.Authors.Remove(authorToDelete);
            db.SaveChanges();
        }
    }
}