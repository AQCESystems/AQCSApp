using AQCSApp.Web.Data.Entities;
using System.Linq;

namespace AQCSApp.Web.Data
{
    public interface IFishFamilyRepository : IGenericRepository<FishFamily>
    {
        IQueryable GetAllWithUsers();
    }
}
