using Microsoft.AspNetCore.Identity;

namespace AQCSApp.Web.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
