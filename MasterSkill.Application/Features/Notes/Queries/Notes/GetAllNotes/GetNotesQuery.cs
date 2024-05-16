using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkill.Application.Features.Note.Queries.Notes.GetAllNotes
{
    public record GetNotesQuery : IRequest<List<NoteDto>>;
}
