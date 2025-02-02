﻿using Inventory_management.dal.Models.Language;
using Inventory_management.dal.Models.User;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Data
{
    public static class CreateAdminData
    {
        public async static Task CreateDataTask(IHost host)
        {
            IWebHostEnvironment _env = host.Services.GetService<IWebHostEnvironment>();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var _dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await _dbContext.Database.MigrateAsync();

                var context = services.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await context.Roles.AnyAsync())
                {
                    await context.CreateAsync(new IdentityRole { Name = "Administrator" });
                    await context.CreateAsync(new IdentityRole { Name = "User" });
                }

                var userContext = services.GetRequiredService<UserManager<ApplicationUser>>();

                var admin = await userContext.FindByNameAsync("admin");

                if (admin == null)
                {
                    ApplicationUser adminUser = new ApplicationUser
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        Email = $"admin@.invertary.com",
                        UserName = "admin",
                        PhoneNumber = "+99361924133",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };

                    await userContext.CreateAsync(adminUser, "Password1!");
                    await userContext.AddToRoleAsync(adminUser, "Administrator");
                    await userContext.AddToRoleAsync(adminUser, "User");
                }


                List<Language> languages = new List<Language>();
                languages.Add(new Language() { Culture = "ru", Name = "Русский", DisplayOrder = 0, IsPublish = true });
                languages.Add(new Language() { Culture = "en", Name = "English", DisplayOrder = 1, IsPublish = true });
                languages.Add(new Language() { Culture = "tk", Name = "Türkmençe", DisplayOrder = 2, IsPublish = true });

                foreach (var lng in languages)
                {
                    var language = await _dbContext.Languages.SingleOrDefaultAsync(s => s.Culture == lng.Culture);
                    if (language == null)
                    {
                        _dbContext.Languages.Add(lng);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }

    }
}
