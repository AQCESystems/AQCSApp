using AQCSApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AQCSApp.Web.Data
{
    public class FishRepository : GenericRepository<Fish>, IFishRepository
    {
        private readonly DataContext context;

        public FishRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.Fishes.Include(p => p.User);
        }
    }    
}
