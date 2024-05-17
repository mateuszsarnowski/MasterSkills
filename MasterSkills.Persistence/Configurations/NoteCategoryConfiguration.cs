using MasterSkills.Domain.Entities.Notes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkills.Persistence.Configurations
{
    public class NoteCategoryConfiguration : IEntityTypeConfiguration<NoteCategory>
    {
        public void Configure(EntityTypeBuilder<NoteCategory> modelBuilder)
        {
            modelBuilder.HasData(
                new NoteCategory { Id = 1, Name = "General" },
                new NoteCategory { Id = 2, Name = "Work" },
                new NoteCategory { Id = 3, Name = "Personal" }
                );

            modelBuilder.Property(q => q.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
