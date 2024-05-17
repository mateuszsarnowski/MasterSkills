using MasterSkills.Application.Exceptions;
using MasterSkills.Application.Contracts.Persistence;
using MediatR;

namespace MasterSkills.Application.Features.Notes.Commands.DeleteNote
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
                throw new NotFoundException(nameof(noteToDelete), request.Id);

            await _noteRepository.DeleteAsync(noteToDelete);

            return Unit.Value;

        }
    }
}
