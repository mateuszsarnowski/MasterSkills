using AutoMapper;
using MasterSkill.Application.Features.Note.Queries.Notes.GetAllNotes;
using MasterSkill.Application.Features.Note.Queries.Notes.GetNoteDetails;
using MasterSkills.Domain.Entities.Notes;

namespace MasterSkill.Application.MappingProfiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<NoteDto, Note>().ReverseMap();
            CreateMap<NoteDetailsDto, Note>().ReverseMap();
        }
    }
}
