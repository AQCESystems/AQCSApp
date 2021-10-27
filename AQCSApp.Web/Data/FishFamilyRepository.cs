using AQCSApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AQCSApp.Web.Data
{

    public class FishFamilyRepository : GenericRepository<FishFamily>, IFishFamilyRepository
    {
        private readonly DataContext context;
        public FishFamilyRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.FishFamilies.Include(p => p.User);
        }
    }
 }
