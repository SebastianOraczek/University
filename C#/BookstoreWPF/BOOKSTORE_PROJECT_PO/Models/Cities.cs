using System.Collections.Generic;

namespace BOOKSTORE_PROJECT_PO.Models
{
    /// <summary>
    /// City model generated automatically based on a template
    /// </summary>
    public partial class Cities
    {
        public Cities()
        {
            this.Customers = new HashSet<Customers>();
        }
    
        public int ID { get; set; }
        public string CityName { get; set; }
    
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
