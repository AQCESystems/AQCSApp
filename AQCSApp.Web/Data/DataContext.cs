
namespace AQCSApp.Web.Data
{
    using AQCSApp.Web.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
       
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<FishFamily> FishFamilies { get; set; }
       // public object Products { get; internal set; }
    }
}
