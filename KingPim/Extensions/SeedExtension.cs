using KingPim.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Extensions
{
    public static class SeederExtensions
    {
        public static IWebHost SeedData(this IWebHost webhost)
        {
            using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                // alternatively resolve UserManager instead and pass that if only think you want to seed are the users
               var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                {
                    Seed.SeedAsync(dbContext).GetAwaiter().GetResult();
                    return (webhost);
                    
                }
            }
        }
    }
}

