using AQCSApp.Web.Data.Entities;

namespace AQCSApp.Web.Data
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DataContext context) : base(context)
        {

        }
    }
}
