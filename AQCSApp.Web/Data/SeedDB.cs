

namespace AQCSApp.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;


    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.FishFamilies.Any())
            {
                this.AddFishFamily("Ciclidos");
                this.AddFishFamily("Ciprinidos");
                this.AddFishFamily("Caracidos");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddFishFamily(string name)
        {
            this.context.FishFamilies.Add(new FishFamily
            {
                Name = name,                
            });
        }
    }

}
