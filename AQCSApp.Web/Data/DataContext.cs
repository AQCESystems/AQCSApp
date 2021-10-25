using AQCSApp.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace AQCSApp.Web.Data
{

    public class DataContext : IdentityDbContext<User>
    {

        public DbSet<FishFamily> FishFamilies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Fish> Fishes { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
       

        
      
    }
}
