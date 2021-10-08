
namespace AQCSApp.Web.Data
{
    using AQCSApp.Web.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
