using Inventory_management.dal.Models.Language;
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
