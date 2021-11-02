using System.Threading.Tasks;
using AQCSApp.Web.Data.Entities;
using AQCSApp.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace AQCSApp.Web.Helpers
{
	

	public class UserHelper : IUserHelper
	{
		private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserHelper(
			UserManager<User> userManager, 
			SignInManager<User> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		public async Task<IdentityResult> AddUserAsync(User user, string password)
		{
			return await this.userManager.CreateAsync(user, password);
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			return await this.userManager.FindByEmailAsync(email);
		}

		public async Task<SignInResult> LoginAsync(LoginViewModel model)
		{
			return await this.signInManager.PasswordSignInAsync(
				model.Username,
				model.Password,
				model.RememberMe,
				false);//Si este se pone a true se configura para que en un número de intentos se bloquee el usuario.
					   //Este parámetro se pone en el Starup	
		}

		public async Task LogoutAsync()
		{
			await this.signInManager.SignOutAsync();
		}

	}

}
