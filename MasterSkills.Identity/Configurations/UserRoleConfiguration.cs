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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "f6bc8006-a62a-4181-a3c8-8389aa17658b",
                   UserId = "3d199b5a-0e87-4d95-845f-d6778cc44651"
               },
               new IdentityUserRole<string>
               {
                   RoleId = "f2a0286d-20c2-4f78-906c-9bf50c823a89",
                   UserId = "13bbc585-e343-4681-adf2-feb4ad94dc09"
               }
                                                         );
        }
    }
}
