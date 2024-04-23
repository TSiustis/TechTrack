using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Techtrack.Ui.Data;

namespace Techtrack.Ui
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Check if there are any users in the database
            if (await userManager.Users.AnyAsync())
            {
                return; // Database has been already seeded with users
            }

            // Seed users
            var users = new ApplicationUser[]
            {
                new() { Id = "46187ce0-5637-4435-805a-48c59ebface6", UserName = "user1@example.com", Email = "user1@example.com", PhoneNumberConfirmed = true, EmailConfirmed = true },
                new() { Id = "9713413c-50a6-429e-a01b-0ed725842b1c", UserName = "user1@example.com", Email = "user2@example.com", PhoneNumberConfirmed = true, EmailConfirmed = true },
                new() { Id = "c4970886-a8cb-4e2a-aab9-6231d092d913", UserName = "user1@example.com", Email = "user3@example.com", PhoneNumberConfirmed = true, EmailConfirmed = true },
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "P@ssw0rd");
            }
        }
    }
}
