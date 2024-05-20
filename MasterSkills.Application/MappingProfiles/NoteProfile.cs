using AutoMapper;
using MasterSkills.Application.Features.Notes.Commands.CreateNote;
using MasterSkills.Application.Features.Notes.Commands.UpdateNote;
using MasterSkills.Application.Features.Notes.Queries.Notes.GetAllNotes;
using MasterSkills.Application.Features.Notes.Queries.Notes.GetNoteDetails;
using MasterSkills.Domain.Entities.Notes;

namespace MasterSkills.Application.MappingProfiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<NoteDto, Note>().ReverseMap();
            CreateMap<NoteDetailsDto, Note>().ReverseMap();
            CreateMap<CreateNoteCommand, Note>();
            CreateMap<UpdateNoteCommand, Note>();
            
        }
    }
}
