using System;

namespace BOOKSTORE_PROJECT_PO.Models
{
    /// <summary>
    /// Book model generated automatically based on a template
    /// </summary>
    public partial class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime PublishedYear { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> AuthorId { get; set; }
        public int StatusId { get; set; }
        public Nullable<int> CustomerId { get; set; }
    
        public virtual Authors Authors { get; set; }
        public virtual Customers Customers { get; set; }
        public virtual Status Status { get; set; }
    }
}
