using Microsoft.EntityFrameworkCore;

namespace VidlyNet7.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Movie> Movies => Set<Movie>();

    }
}
