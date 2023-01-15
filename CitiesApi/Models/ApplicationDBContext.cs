using Microsoft.EntityFrameworkCore;

namespace CitiesApi.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
    }
}
