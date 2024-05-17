using MasterSkills.Application.Contracts.Persistence;
using MasterSkills.Domain.Entities.Notes;
using MasterSkills.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkills.Persistence.Repositories
{
    public class NoteCategoryRepository : GenericRepository<NoteCategory>, INoteCategoryRepository
    {
        public NoteCategoryRepository(MasterSkillsDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsNoteCategoryNameUnique(string name)
        {
            return await _context.NoteCategories.AnyAsync(nc => nc.Name == name);
        }
    }
}
