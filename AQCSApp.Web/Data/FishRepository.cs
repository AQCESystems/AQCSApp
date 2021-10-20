using AQCSApp.Web.Data.Entities;

namespace AQCSApp.Web.Data
{
    public class FishRepository : GenericRepository<Fish>, IFishRepository
    {
        public FishRepository(DataContext context) : base(context)
        { 
        }
    }    
}
