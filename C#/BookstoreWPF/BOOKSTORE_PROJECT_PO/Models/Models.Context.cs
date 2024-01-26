using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BOOKSTORE_PROJECT_PO.Models
{
    
    public partial class BookstoreDBEntities : DbContext
    {
        /// <summary>
        /// Automatically generated context, based on a template.
        /// </summary>
        public BookstoreDBEntities()
            : base("name=BookstoreDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
