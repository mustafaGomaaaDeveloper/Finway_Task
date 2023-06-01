using Microsoft.AspNetCore.Identity;
using System.Data;

namespace Finway.extantion
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!roleManager.Roles.Any())
            {

                await roleManager.CreateAsync(new IdentityRole("Admin"));

            }
        }

    }
}
