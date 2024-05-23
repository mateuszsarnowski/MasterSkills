using MasterSkills.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkills.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
               new ApplicationUser
               {
                   Id = "3d199b5a-0e87-4d95-845f-d6778cc44651",
                   Email = "user@localhost.com",
                   NormalizedEmail = "USER@LOCALHOST.COM",
                   FirstName = "Normal",
                   LastName = "User",
                   UserName = "user@localhost.com",
                   NormalizedUserName = "USER@LOCALHOST.COM",
                   PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                   EmailConfirmed = true
               },
               new ApplicationUser
               {
                   Id = "13bbc585-e343-4681-adf2-feb4ad94dc09",
                   Email = "admin@localhost.com",
                   NormalizedEmail = "ADMIN@LOCALHOST.COM",
                   FirstName = "Admin",
                   LastName = "User",
                   UserName = "admin@localhost.com",
                   NormalizedUserName = "ADMIN@LOCALHOST.COM",
                   PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                   EmailConfirmed = true
               }
           );

        }
    }
}
