using AQCSApp.Web.Data.Entities;

namespace AQCSApp.Web.Data
{

    public class FishFamilyRepository : GenericRepository<FishFamily>, IFishFamilyRepository
    {
        public FishFamilyRepository(DataContext context) : base(context)
        {
        }
    }

}
