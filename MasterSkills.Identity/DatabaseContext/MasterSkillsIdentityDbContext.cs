using MasterSkills.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkills.Identity.DbContext
{
    public class MasterSkillsIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public MasterSkillsIdentityDbContext(DbContextOptions<MasterSkillsIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(MasterSkillsIdentityDbContext).Assembly);
        }
    }
}
