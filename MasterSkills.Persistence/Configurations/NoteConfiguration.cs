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
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> modelBuilder)
        {
            modelBuilder.Property(q => q.Title)
                .HasMaxLength(255)
                .IsRequired();
            
            modelBuilder.Property(q => q.Content)
                .IsRequired();
        }
    }
}
