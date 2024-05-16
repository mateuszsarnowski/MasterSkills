﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkill.Application.Features.Note.Queries.Notes.GetNoteDetails
{
    public record GetNoteDetailsQuery(int Id) : IRequest<NoteDetailsDto>;
}
