using AutoMapper;
using MasterSkill.Application.Features.Note.Queries.Categories.GetAllCategories;
using MasterSkill.Application.Features.Note.Queries.NoteCategories.GetNoteCategoryDetails;
using MasterSkills.Domain.Entities.Notes;


namespace MasterSkill.Application.MappingProfiles
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
