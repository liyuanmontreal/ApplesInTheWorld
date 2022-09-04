using Microsoft.EntityFrameworkCore;
using AppleApp.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AppleApp.Areas.Identity.Data;

namespace AppleApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppleAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AppleApp.Model.Apple>? Apple { get; set; }
        public DbSet<AppleApp.Model.Recipe>? Recipe { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Apple>().ToTable("Apple");
            builder.Entity<Recipe>().ToTable("Recipe");
         
        }



        public DbSet<AppleApp.Model.Wine>? Wine { get; set; }

      


        
    }
}