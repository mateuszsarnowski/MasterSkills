using MasterSkills.Domain.Common;
using MasterSkills.Domain.Entities.Notes;
using Microsoft.EntityFrameworkCore;

namespace MasterSkills.Persistence.DatabaseContext
{
    public class MasterSkillsDatabaseContext : DbContext
    {
        public MasterSkillsDatabaseContext(DbContextOptions<MasterSkillsDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteCategory> NoteCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MasterSkillsDatabaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                //.Where(q => q.State ==  EntityState.Added || q.State == EntityState.Modified )
                )
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
