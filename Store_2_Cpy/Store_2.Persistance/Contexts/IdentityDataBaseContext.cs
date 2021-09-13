using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store_2.Application.Interface.Context;
using Store_2.Domain.Attributes;
using Store_2.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Persistance.Contexts
{
    public class IdentityDataBaseContext : IdentityDbContext<User>, IIdentityDatabaseContext
    {
        public IdentityDataBaseContext(DbContextOptions<IdentityDataBaseContext> options) : base(options)
        {

        }
        
        
        protected override void OnModelCreating(ModelBuilder builder)
        {

            
            builder.Entity<IdentityUser<string>>().ToTable("Users", "Identity");
            builder.Entity<IdentityRole<string>>().ToTable("Roles", "Identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RolesClaims", "Identity");
            builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserClaim<string>>().ToTable("UserClaims", "Identity");
            builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserLogin<string>>().ToTable("UserLogins", "Identity");
            builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<string>>().ToTable("UserRoless", "Identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Identity");

            builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserLogin<string>>().HasKey(p => new { p.LoginProvider, p.ProviderKey });
            builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
            builder.Entity<IdentityUserToken<string>>().HasKey(p => new { p.LoginProvider,p.UserId, p.Name });
            //base.OnModelCreating(builder);
        }

    }
}
