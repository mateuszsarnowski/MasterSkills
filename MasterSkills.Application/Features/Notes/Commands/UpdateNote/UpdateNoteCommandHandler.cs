using AutoMapper;
using MasterSkills.Application.Contracts.Persistence;
using MediatR;

namespace MasterSkills.Application.Features.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;

        public UpdateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }
        public async Task<int> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data

            var noteToUpdate = _mapper.Map<Domain.Entities.Notes.Note>(request);
            await _noteRepository.UpdateAsync(noteToUpdate);

            return noteToUpdate.Id;

        }
    }
}
