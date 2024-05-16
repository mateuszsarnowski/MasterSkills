using AutoMapper;
using MasterSkill.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkill.Application.Features.Note.Queries.NoteCategories.GetNoteCategoryDetails
{
    public class GetNoteCategoryDetailsQueryHandler : IRequestHandler<GetNoteCategoryDetailsQuery, NoteCategoryDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly INoteCategoryRepository _noteCategoryRepository;

        public GetNoteCategoryDetailsQueryHandler(IMapper mapper, INoteCategoryRepository noteCategoryRepository)
        {
            _mapper = mapper;
            _noteCategoryRepository = noteCategoryRepository;
        }
        public async Task<NoteCategoryDetailsDto> Handle(GetNoteCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var categoryDetails = await _noteCategoryRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<NoteCategoryDetailsDto>(categoryDetails);
            return result;
        }
    }
}
