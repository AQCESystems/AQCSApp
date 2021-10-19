
namespace AQCSApp.Web.Data
{
    using AQCSApp.Web.Data.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : IdentityDbContext<User>
    {

        public DbSet<FishFamily> FishFamilies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        
      
    }
}
