using System;

namespace BOOKSTORE_PROJECT_PO.Dal_Models
{
    /// <summary>
    /// Model created to display book in the table without ID property
    /// </summary>
    public class BookDalModel
    {
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public string LastCustomer { get; set; }
    }
}
