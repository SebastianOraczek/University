using System;
using System.Collections.Generic;

namespace BOOKSTORE_PROJECT_PO.Models
{
    /// <summary>
    /// Customer model generated automatically based on a template
    /// </summary>
    public partial class Customers
    {
        public Customers()
        {
            this.Books = new HashSet<Books>();
        }
    
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int OrderQuantity { get; set; }
        public Nullable<int> CityId { get; set; }
    
        public virtual ICollection<Books> Books { get; set; }
        public virtual Cities Cities { get; set; }
    }
}
