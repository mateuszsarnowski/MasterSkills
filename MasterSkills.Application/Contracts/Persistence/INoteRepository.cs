using MasterSkills.Domain.Entities.Notes;


namespace MasterSkills.Application.Contracts.Persistence
{
    public interface INoteRepository : IGenericRepository<Note>
    {
        Task<List<Note>> GetNotesByCategoryAsync(int categoryId);
    }
}
