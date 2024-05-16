using AutoMapper;
using MasterSkill.Application.Contracts.Persistence;
using MasterSkill.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkill.Application.Features.Note.Queries.Notes.GetNoteDetails
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
                throw new NotFoundException(nameof(Note), request.Id);

            var result = _mapper.Map<NoteDetailsDto>(note);
            return result;
        }
    }
}
