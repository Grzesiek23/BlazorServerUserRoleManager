using BlazorServerUserRoleManager.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlazorServerUserRoleManager.Context;

public static class SeedContext
{
    public static async Task SeedRolesAsync(RoleManager<ApplicationRole> roleManager)
    {
        //Seed Roles
        await roleManager.CreateAsync(new ApplicationRole("SuperAdmin", "SA"));
        await roleManager.CreateAsync(new ApplicationRole("Admin", "A"));
        await roleManager.CreateAsync(new ApplicationRole("Basic", "B"));
    }

    public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager)
    {
        var user = new ApplicationUser()
        {
            FirstName = "Super",
            LastName = "Admin",
            UserName = "super@admin.com",
            Email = "super@admin.com",
            EmailConfirmed = true
        };

        if (userManager.Users.All(u => u.Id != user.Id))
        {
            var check = await userManager.FindByEmailAsync(user.Email);

            if (check == null)
            {
                await userManager.CreateAsync(user, "P@ssw0rd!");
                await userManager.AddToRolesAsync(user, new[] {"SuperAdmin", "Admin", "Basic"});
            }
        }
    }
}