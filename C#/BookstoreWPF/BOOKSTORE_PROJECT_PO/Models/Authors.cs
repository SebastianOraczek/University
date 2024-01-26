using System.Collections.Generic;

namespace BOOKSTORE_PROJECT_PO.Models
{
    /// <summary>
    /// Author model generated automatically based on a template
    /// </summary>
    public partial class Authors
    {
        public Authors()
        {
            this.Books = new HashSet<Books>();
        }
    
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public virtual ICollection<Books> Books { get; set; }
    }
}
