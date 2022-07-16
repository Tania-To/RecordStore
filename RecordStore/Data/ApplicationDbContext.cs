using Microsoft.EntityFrameworkCore;
using RecordStore.Model;

namespace RecordStore.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {

        }
        public DbSet<Manager> Manager { get; set; }
         public DbSet<Associate> Associate { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Store> Store { get; set; }

    }
}
