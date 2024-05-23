using MasterSkills.Application.Contracts.Persistence;
using MasterSkills.Domain.Entities.Notes;
using MasterSkills.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MasterSkills.Persistence.Repositories
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(MasterSkillsDatabaseContext context) : base(context)
        {
        }

        public async Task<List<Note>> GetNotesByCategoryAsync(int categoryId)
        {
            var notes = await _context.Notes
                .Where(n => n.NoteCategoryId == categoryId)
                .ToListAsync();
            return notes;
        }
    }
}
