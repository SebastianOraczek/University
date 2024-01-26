
using Microsoft.AspNetCore.Identity;
using  MN_SO_APS_PROJECT.Enums;
using MN_SO_APS_PROJECT.Areas.Identity.Data;

namespace MN_SO_APS_PROJECT.Seed
{
    public class SeedData
    {
        public static async Task SeedDataAsync(IApplicationBuilder applicationBuilder)
        {
            try
            {

            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();

            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string adminUserEmail = "admin@gmail.com";
            string adminUserPassword = "Aaaaa123!";


                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                {
                    Login = adminUserEmail,
                    UserName = adminUserEmail,
                    Email = adminUserEmail,
                    Password = adminUserPassword,
                    EmailConfirmed = true,
                    CityId = 1,
                    CountryId = 1,
                };

                await userManager.CreateAsync(newAdminUser, "password");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}