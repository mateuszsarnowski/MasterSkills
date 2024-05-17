using MediatR;

namespace MasterSkills.Application.Features.Notes.Queries.NoteCategories.GetAllNoteCategories
{
    public record GetAllNoteCategoriesQuery : IRequest<List<NoteCategoryDto>>;

}
