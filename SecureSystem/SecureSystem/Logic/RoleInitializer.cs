using SecureSystem.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CustomIdentityApp
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "Afds4321";
            string address = "ADMINstreet";
            string fullname = "ADMINadmin";
            string nameorg = "ADMINorg";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("client") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("client"));
            }
                if (await roleManager.FindByNameAsync("employee") == null)
                {
                    await roleManager.CreateAsync(new IdentityRole("employee"));
                }
                if (await userManager.FindByNameAsync(adminEmail) == null)
                {
                User admin = new User { Email = adminEmail, UserName = adminEmail, Address = address, FullName = fullname, NameOrg = nameorg };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }



            }
        }
    }
}