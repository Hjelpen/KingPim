using KingPim.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Data
{
 
    public class Seed
    {
        private ApplicationDbContext _context;

        public Seed(ApplicationDbContext context)
        {
            _context = context;
        }

        public static async Task SeedAsync(ApplicationDbContext _context)
        {
            var user = new ApplicationUser
            {
                UserName = "Admin@kingpim.com",
                NormalizedUserName = "admin@kingpim.com",
                Email = "Admin@kingpim.com",
                NormalizedEmail = "admin@kingpim.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "admin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
            }

            if (!_context.Roles.Any(r => r.Name == "publisher"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "publisher", NormalizedName = "publisher" });
            }

            if (!_context.Roles.Any(r => r.Name == "editor"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "editor", NormalizedName = "editor" });
            }

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "password");
                user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(_context);
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "admin");
            }

            await _context.SaveChangesAsync();
        }
    }
}
        

