using BOOKSTORE_PROJECT_PO.Dal_Models.StatusModels;
using BOOKSTORE_PROJECT_PO.Models;
using System.Collections.Generic;
using System.Linq;

namespace BOOKSTORE_PROJECT_PO.Dals
{
    /// <summary>
    /// Data source for status
    /// </summary>
    internal class StatusDal
    {
        private BookstoreDBEntities db = new BookstoreDBEntities();

        /// <summary>
        /// Fetching status information to include in a combobox
        /// </summary>
        public IList<StatusDalModelForSelector> getStatusForSelectorList =>
            db.Status.Select
            (
                status => new StatusDalModelForSelector
                {
                    ID = status.ID,
                    Name = status.StatusName,
                }).ToList();

        /// <summary>
        /// Fetching status name to include in a table
        /// </summary>
        public IList<StatusDalModel> getCStatusList =>
           db.Status
               .Select(status => new StatusDalModel
               {
                   Status = status.StatusName,
               }).ToList();
    }
}
