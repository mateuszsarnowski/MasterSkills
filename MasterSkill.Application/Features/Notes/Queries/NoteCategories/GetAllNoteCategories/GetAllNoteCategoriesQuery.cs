using MasterSkill.Application.Features.Note.Queries.Categories.GetAllCategories;
using MediatR;

namespace MasterSkill.Application.Features.Note.Queries.NoteCategories.GetAllNoteCategories
{
    public record GetAllNoteCategoriesQuery : IRequest<List<NoteCategoryDto>>;

}
