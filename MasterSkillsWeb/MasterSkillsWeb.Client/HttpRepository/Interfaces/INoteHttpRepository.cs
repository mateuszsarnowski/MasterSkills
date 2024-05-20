using MasterSkills.Application.Features.Notes.Queries.Notes.GetAllNotes;

namespace MasterSkillsWeb.Client.HttpRepository.Interfaces
{
    public interface INoteHttpRepository
    {
        Task<List<NoteDto>> GetAllAsync();
    }
}
