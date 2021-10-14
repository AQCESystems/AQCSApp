using System.Threading.Tasks;
using AQCSApp.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace AQCSApp.Web.Helpers
{
  
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
    }

}
