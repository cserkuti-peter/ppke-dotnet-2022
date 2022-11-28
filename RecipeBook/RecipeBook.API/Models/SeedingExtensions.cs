using Microsoft.AspNetCore.Identity;
using RecipeBook.API.Models.Authentication;

namespace RecipeBook.API.Models
{
    public static class SeedingExtensions
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

                //  Seed roles
                if (!roleManager.RoleExistsAsync(UserRoles.Admin).Result)
                    roleManager.CreateAsync(new IdentityRole(UserRoles.Admin)).Wait();
                if (!roleManager.RoleExistsAsync(UserRoles.User).Result)
                    roleManager.CreateAsync(new IdentityRole(UserRoles.User)).Wait();
            }

            return host;
        }
    }

}
