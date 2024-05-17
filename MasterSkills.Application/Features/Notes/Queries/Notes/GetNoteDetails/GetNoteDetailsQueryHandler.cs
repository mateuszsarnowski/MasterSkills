using AutoMapper;
using MasterSkills.Application.Exceptions;
using MasterSkills.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkills.Application.Features.Notes.Queries.Notes.GetNoteDetails
{
    internal class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noterepository;

        public GetNoteDetailsQueryHandler(IMapper mapper, INoteRepository noterepository)
        {
            _mapper = mapper;
            _noterepository = noterepository;
        }
        public async Task<NoteDetailsDto> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var note = await _noterepository.GetByIdAsync(request.Id);

            if (note == null)
                throw new NotFoundException(nameof(note), request.Id);

            var result = _mapper.Map<NoteDetailsDto>(note);
            return result;
        }
    }
}
