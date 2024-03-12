using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Email_forgot.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationUserDb : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserDb()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Tbl_ApplicationUser", "dbo");
            modelBuilder.Entity<IdentityRole>().ToTable("Tbl_IdentityRole", "dbo");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("Tbl_IdentityUserClaim", "dbo");
            modelBuilder.Entity<IdentityUserRole>().ToTable("Tbl_IdentityUserRole", "dbo");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("Tbl_IdentityUderLogin", "dbo");
        }
        public static ApplicationUserDb Create()
        {
            return new ApplicationUserDb();
        }
    }
}