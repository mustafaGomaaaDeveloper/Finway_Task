using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Reflection;
using System.Security.Claims;

namespace Finway.extantion
{
    public static class DefaultUsers
    {

        public static async Task SeedBasicUserAsync(UserManager<IdentityUser> usermanger, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "admin@admin.com",
                Email= "admin@admin.com"
            };
            var user = await usermanger.FindByNameAsync(defaultUser.UserName);

            if (user == null)
            {
                await usermanger.CreateAsync(defaultUser, "P@ssword123");
                await usermanger.AddToRoleAsync(defaultUser, "Admin");
            }
        }    


        



    }
}
