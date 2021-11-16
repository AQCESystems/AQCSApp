using System;
using System.Linq;
using System.Threading.Tasks;
using AQCSApp.Web.Helpers;
using AQCSApp.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace AQCSApp.Web.Data
{


    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        //private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
           // this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            await this.userHelper.CheckRoleAsync("Admin");//Si no existe el rol Admin , lo crea.
            await this.userHelper.CheckRoleAsync("Customer");//Si no existe el Rol Customer . lo crea.


            //Add user
            var user = await this.userHelper.GetUserByEmailAsync("pablomartinezros@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Pablo",
                    LastName = "Martinez",
                    Email = "pablomartinezros@gmail.com",
                    UserName = "pablomartinezros@gmail.com",
                    PhoneNumber ="123123123"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");//Asigna el rol Admin al usuario.
            }

            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }
                                     
            //Add Families
            if (!this.context.FishFamilies.Any())
            {
                this.AddFishFamily("Ciclidos",user);
                this.AddFishFamily("Ciprinidos", user);
                this.AddFishFamily("Caracidos", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddFishFamily(string name, User user)
        {
            this.context.FishFamilies.Add(new FishFamily
            {
                Name = name, 
                User = user
            });
        }

    }

}
