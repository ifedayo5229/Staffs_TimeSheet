using System;
using System.Linq;
using System.Threading.Tasks;
using Staffs_TimeSheet.Data.DbContexts;
using Staffs_TimeSheet.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Staffs_TimeSheet.Users
{
    public static class MigrationHelper
    {
        public static void MigrateDatabaseContext(IServiceProvider svp)
        {
            var applicationDbContext = svp.GetRequiredService<ApplicationDbContext>();
            applicationDbContext.Database.Migrate();
        }

        public static async Task MigrateUser(IServiceProvider svp)
        {
            var userManager = svp.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = svp.GetRequiredService<RoleManager<IdentityRole>>();

            var adminRole = "Administrator";
            var userRole = "User";
            var password = "Password10##";

            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(adminRole));
            await roleManager.CreateAsync(new IdentityRole(userRole));

            //Create Default Users
            var firstUser = new ApplicationUser { UserName = "ST001", Email = "segun@larfage.com", PhoneNumber = "07010000000", EmailConfirmed = true, PhoneNumberConfirmed = true };
            var secondUser = new ApplicationUser { UserName = "ST002", Email = "tope@larfage.com", PhoneNumber = "07020000000", EmailConfirmed = true, PhoneNumberConfirmed = true };
            var AdminUser = new ApplicationUser { UserName = "ST003", Email = "Seun@larfage.com", PhoneNumber = "07030000000", EmailConfirmed = true, PhoneNumberConfirmed = true };

            if (userManager.Users.All(u => (u.Email != firstUser.Email && u.Email != secondUser.Email && u.Email != AdminUser.Email)))
            {
                await userManager.CreateAsync(firstUser, password);
                await userManager.AddToRoleAsync(firstUser, userRole);

                await userManager.CreateAsync(secondUser, password);
                await userManager.AddToRoleAsync(secondUser, userRole);

                await userManager.CreateAsync(AdminUser, password);
                await userManager.AddToRoleAsync(AdminUser, adminRole);
            }
        }
    }
}