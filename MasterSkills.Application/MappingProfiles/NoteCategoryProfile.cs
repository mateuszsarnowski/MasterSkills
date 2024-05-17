using AutoMapper;
using MasterSkills.Application.Features.Notes.Queries.NoteCategories.GetAllNoteCategories;
using MasterSkills.Application.Features.Notes.Queries.NoteCategories.GetNoteCategoryDetails;
using MasterSkills.Domain.Entities.Notes;


namespace MasterSkills.Application.MappingProfiles
{
    public class NoteCategoryProfile : Profile
    {
        public NoteCategoryProfile()
        {
            CreateMap<NoteCategoryDto, NoteCategory>().ReverseMap();
            CreateMap<NoteCategoryDetailsDto, NoteCategory>().ReverseMap();
        }
    }
}
