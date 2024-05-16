﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkill.Application.Features.Note.Queries.NoteCategories.GetNoteCategoryDetails
{
    public record GetNoteCategoryDetailsQuery (int Id) : IRequest<NoteCategoryDetailsDto>;

}