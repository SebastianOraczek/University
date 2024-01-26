using System.Collections.Generic;

namespace BOOKSTORE_PROJECT_PO.Models
{
    /// <summary>
    /// Status model generated automatically based on a template
    /// </summary>
    public partial class Status
    {
        public Status()
        {
            this.Books = new HashSet<Books>();
        }
    
        public int ID { get; set; }
        public string StatusName { get; set; }
    
        public virtual ICollection<Books> Books { get; set; }
    }
}
