using AutoMapper;
using MasterSkills.BlazorSpa.Models.Notes;
using MasterSkills.BlazorSpa.Services.Base;

namespace MasterSkills.BlazorSpa.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<NoteVM, NoteDto>().ReverseMap();
            CreateMap<NoteVM, CreateNoteCommand>().ReverseMap();
            CreateMap<NoteVM, UpdateNoteCommand>().ReverseMap();
        }
    }
}
