using AutoMapper;
using MasterSkill.Application.Contracts.Logging;
using MasterSkill.Application.Contracts.Persistence;
using MasterSkill.Application.Exceptions;
using MediatR;

namespace MasterSkill.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;
        private readonly IAppLogger<CreateNoteCommandHandler> _logger;

        public CreateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository, IAppLogger<CreateNoteCommandHandler> logger)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
            _logger = logger;
        }
        public async Task<int> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateNoteCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning($"Validation errors in create request for {0}", nameof(Note));
                throw new BadRequestException("Invalid note", validationResult);
                
            }

            var noteToCreate = _mapper.Map<MasterSkills.Domain.Entities.Notes.Note>(request);
            await _noteRepository.CreateAsync(noteToCreate);

            return noteToCreate.Id;

        }
    }
}
