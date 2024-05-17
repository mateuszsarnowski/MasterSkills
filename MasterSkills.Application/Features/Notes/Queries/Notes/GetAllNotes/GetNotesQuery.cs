using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkills.Application.Features.Notes.Queries.Notes.GetAllNotes
{
    public record GetNotesQuery : IRequest<List<NoteDto>>;
}
