using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkills.Application.Features.Notes.Queries.NoteCategories.GetNoteCategoryDetails
{
    public record GetNoteCategoryDetailsQuery(int Id) : IRequest<NoteCategoryDetailsDto>;

}
