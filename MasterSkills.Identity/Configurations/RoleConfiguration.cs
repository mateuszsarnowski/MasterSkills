using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkills.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
              new IdentityRole
              {
                  Id = "f6bc8006-a62a-4181-a3c8-8389aa17658b",
                  Name = "User",
                  NormalizedName = "USER"
              },
              new IdentityRole
              {
                  Id = "f2a0286d-20c2-4f78-906c-9bf50c823a89",
                  Name = "Administrator",
                  NormalizedName = "ADMINISTRATOR"
              }
                                                         );
        }
    }
}
