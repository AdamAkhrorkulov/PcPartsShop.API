using Microsoft.AspNetCore.Identity;

namespace PcPartsShop.API.Infrastructure.Identity
{
    public class IdentityDataSeeder
    {
        public static async Task SeedRolesAndAdminUser(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var adminEmail = "admin@example.com";
            var adminPassword = "Admin123!";

            
            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin != null)
            {
                var rolesForUser = await userManager.GetRolesAsync(existingAdmin);
                if (!rolesForUser.Contains("Admin"))
                {
                    await userManager.AddToRoleAsync(existingAdmin, "Admin");
                }

                return; 
            }

            
            var adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

    }
}
