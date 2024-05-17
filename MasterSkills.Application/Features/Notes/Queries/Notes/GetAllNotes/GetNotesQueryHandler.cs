using AutoMapper;
using MasterSkills.Application.Contracts.Persistence;
using MediatR;

namespace MasterSkills.Application.Features.Notes.Queries.Notes.GetAllNotes
{
    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, List<NoteDto>>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;

        public GetNotesQueryHandler(IMapper mapper, INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }
        public async Task<List<NoteDto>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            var notes = await _noteRepository.GetAllAsync();
            var result = _mapper.Map<List<NoteDto>>(notes);

            return result;
        }
    }
}
