
using System.Collections.Generic;
using System.Threading.Tasks;
using AQCSApp.Web.Data.Entities;

namespace AQCSApp.Web.Data
{
    public interface IRepository
    {
        void AddFishFamily(FishFamily fishfamily);

        bool FishFamilyExists(int id);

        IEnumerable<FishFamily> GetFishFamilies();

        FishFamily GetFishFamilies(int id);

        void RemoveFishFamily(FishFamily fishfamily);

        Task<bool> SaveAllAsync();

        void UpdateFishFamily(FishFamily fishfamily);
    }
}