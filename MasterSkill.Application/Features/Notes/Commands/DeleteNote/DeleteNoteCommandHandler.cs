using MasterSkill.Application.Contracts.Persistence;
using MasterSkill.Application.Exceptions;
using MediatR;

namespace MasterSkill.Application.Features.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {

        private readonly INoteRepository _noteRepository;
        public DeleteNoteCommandHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var noteToDelete = await _noteRepository.GetByIdAsync(request.Id);

            if (noteToDelete == null)
                throw new NotFoundException(nameof(Note), request.Id);

            await _noteRepository.DeleteAsync(noteToDelete);

            return Unit.Value;

        }
    }
}
