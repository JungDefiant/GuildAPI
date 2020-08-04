using GuildAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    // This class will seed the user databases with default roles
    public class RoleInitializer
    {
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole
            {
                Name = ApplicationRoles.Administrator,
                NormalizedName = ApplicationRoles.Administrator
                    .ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole
            {
                Name = ApplicationRoles.Manager,
                NormalizedName = ApplicationRoles.Manager
                    .ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        };

        public static void SeedData (IServiceProvider serviceProvider, UserManager<ApplicationUser> users, IConfiguration _config)
        {
            using (var dbContext = new GuildAPIDbContext(serviceProvider
                .GetRequiredService<DbContextOptions<GuildAPIDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
                SeedUsers(users, _config);
            }
        }

        public static void AddRoles (GuildAPIDbContext dbContext)
        {
            if (dbContext.Roles.Any()) return;

            foreach (var role in Roles)
            {
                dbContext.Roles.Add(role);
                dbContext.SaveChanges();
            }
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager, IConfiguration _config)
        {
            if (userManager.FindByEmailAsync(_config["AdminEmail"]).Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = _config["AdminEmail"];
                user.Email = _config["AdminEmail"];
                user.FirstName = "Admin";
                user.LastName = "GuildAPI";

                IdentityResult result = userManager.CreateAsync(user, _config["AdminPassword"]).Result;

                if(result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, ApplicationRoles.Administrator).Wait();
                }
            }
        }
    }
}
