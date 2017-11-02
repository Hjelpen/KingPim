using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KingPim.Models;

namespace KingPim.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
      
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AttributeGroup> AttributeGroups { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SubCategory>();
            builder.Entity<Category>();
            builder.Entity<AttributeGroup>();

            builder.Entity<SubCategoryAttributeGroup>()
       .HasKey(t => new { t.SubCategoryId, t.AttributeGroupId });
        }
    }
}
