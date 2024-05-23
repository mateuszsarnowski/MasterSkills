using MasterSkills.BlazorSpa.Models.Notes;
using MasterSkills.BlazorSpa.Services.Base;

namespace MasterSkills.BlazorSpa.Contracts
{
    public interface INoteService
    {
        Task<List<NoteVM>> GetNotes();
        Task<NoteVM> GetNoteById(int id);
        Task<Response<Guid>> CreateNote(NoteVM note); 
        Task<Response<Guid>> UpdateNote(NoteVM note);
        Task<Response<Guid>> DeleteNote(int id);
    }
}
