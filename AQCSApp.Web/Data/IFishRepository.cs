using AQCSApp.Web.Data.Entities;
using System.Linq;

namespace AQCSApp.Web.Data
{
    public interface IFishRepository : IGenericRepository<Fish>
    {
        IQueryable GetAllWithUsers();
    }
}
