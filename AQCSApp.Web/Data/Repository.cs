using AQCSApp.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AQCSApp.Web.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<FishFamily> GetFishFamilies()
        {
            return this.context.FishFamilies.OrderBy(p => p.Name);
        }

        public FishFamily GetFishFamilies(int id)
        {
            return this.context.FishFamilies.Find(id);
        }

        public void AddFishFamily(FishFamily fishfamily)
        {
            this.context.FishFamilies.Add(fishfamily);
        }

        public void UpdateFishFamily(FishFamily fishfamily)
        {
            this.context.FishFamilies.Update(fishfamily);
        }

        public void RemoveFishFamily(FishFamily fishfamily)
        {
            this.context.FishFamilies.Remove(fishfamily);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool FishFamilyExists(int id)
        {
            return this.context.FishFamilies.Any(p => p.Id == id);
        }
    }


}
