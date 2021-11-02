using AQCSApp.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Esto es para formatear los datos con decimales.
            //Es un ejemplo por si tuviera algun campo
            //modelBuilder.Entity<FishFamily>()
            //    .Property(prop => prop.Price)
            //    .HasColumnType("decimal(18,2)");


            //Este código es para evitar los borrados en cascada.
            //EJ: Si borro un usuario perdería todos los registros relacionados con el.
            var cascadeFKs = modelBuilder.Model
                .G­etEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
                    foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }
            base.OnModelCreating(modelBuilder);

        }




    }
}
