using AutoMapper;
using MasterSkill.Application.Contracts.Logging;
using MasterSkill.Application.Contracts.Persistence;
using MasterSkill.Application.Features.Note.Queries.Categories.GetAllCategories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkill.Application.Features.Note.Queries.NoteCategories.GetAllNoteCategories
{
    public class GetAllNoteCategoriesQueryHandler : IRequestHandler<GetAllNoteCategoriesQuery, List<NoteCategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly INoteCategoryRepository _noteCategoryRepository;
        private readonly IAppLogger<GetAllNoteCategoriesQueryHandler> _logger;

        public GetAllNoteCategoriesQueryHandler(
            IMapper mapper, 
            INoteCategoryRepository noteCategoryRepository,
            IAppLogger<GetAllNoteCategoriesQueryHandler> logger)
        {
            _mapper = mapper;
            _noteCategoryRepository = noteCategoryRepository;
            _logger = logger;
        }
        public async Task<List<NoteCategoryDto>> Handle(GetAllNoteCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _noteCategoryRepository.GetAllAsync();
            var result = _mapper.Map<List<NoteCategoryDto>>(categories);
            _logger.LogInformation("All Note Categories are retrieved");
            return result;
        }
    }
}
