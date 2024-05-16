using MediatR;

namespace MasterSkill.Application.Features.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<int>
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }

}
