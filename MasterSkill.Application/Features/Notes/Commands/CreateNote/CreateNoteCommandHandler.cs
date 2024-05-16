using AutoMapper;
using MasterSkill.Application.Contracts.Persistence;
using MasterSkill.Application.Exceptions;
using MediatR;

namespace MasterSkill.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;

        public CreateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }
        public async Task<int> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateNoteCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid note", validationResult);

            var noteToCreate = _mapper.Map<MasterSkills.Domain.Entities.Notes.Note>(request);
            await _noteRepository.CreateAsync(noteToCreate);

            return noteToCreate.Id;

        }
    }
}
