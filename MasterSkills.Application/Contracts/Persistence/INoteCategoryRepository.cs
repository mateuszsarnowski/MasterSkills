using MasterSkills.Domain.Entities.Notes;


namespace MasterSkills.Application.Contracts.Persistence
{
    public interface INoteCategoryRepository : IGenericRepository<NoteCategory>
    {
        Task<bool> IsNoteCategoryNameUnique(string name);
    }
}
