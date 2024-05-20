using MasterSkills.Application.Contracts.Persistence;
using MasterSkills.Application.UnitTests.Mock;
using Moq;
using AutoMapper;
using MasterSkills.Application.MappingProfiles;
using MasterSkills.Application.Features.Notes.Queries.Notes.GetAllNotes;
using MasterSkills.Application.Contracts.Logging;
using Shouldly;


namespace MasterSkills.Application.UnitTests.Features.Notes.Queries
{
    public class GetNotesQueryHandlerTests
    {
        private readonly Mock<INoteRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetNotesQueryHandler>> _mockAppLogger;

        public GetNotesQueryHandlerTests()
        {
            _mockRepo = MockNoteRepository.GetMockNotesMockRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<NoteProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetNotesQueryHandler>>();
        }

        [Fact]

        public async Task GetNotesListTest()
        {
            var handler = new GetNotesQueryHandler(_mapper, _mockRepo.Object);
            var result = await handler.Handle(new GetNotesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<NoteDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
