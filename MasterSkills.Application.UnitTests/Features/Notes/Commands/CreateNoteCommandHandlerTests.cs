using AutoMapper;
using MasterSkills.Application.Contracts.Logging;
using MasterSkills.Application.Contracts.Persistence;
using MasterSkills.Application.Exceptions;
using MasterSkills.Application.Features.Notes.Commands.CreateNote;
using MasterSkills.Application.UnitTests.Mock;
using MasterSkills.Domain.Entities.Notes;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MasterSkills.Application.UnitTests.Features.Notes.Commands
{
    public class CreateNoteCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<INoteRepository> _mockNoteRepository;
        private readonly Mock<IAppLogger<CreateNoteCommandHandler>> _mockLogger;
        private readonly CreateNoteCommandHandler _handler;

        public CreateNoteCommandHandlerTests()
        {
            // Configure AutoMapper
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateNoteCommand, Note>();
            });

            _mapper = configurationProvider.CreateMapper();

            // Initialize mocks
            _mockNoteRepository = MockNoteRepository.GetMockNotesMockRepository();
            _mockLogger = new Mock<IAppLogger<CreateNoteCommandHandler>>();

            // Initialize handler
            _handler = new CreateNoteCommandHandler(_mapper, _mockNoteRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task Handle_ValidNote_CreatesNote()
        {
            // Arrange
            var command = new CreateNoteCommand
            {
                Title = "New Note",
                Content = "New Content"
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            var allNotes = await _mockNoteRepository.Object.GetAllAsync();
            Assert.True(result > 0);
            Assert.Contains(allNotes, note => note.Title == command.Title && note.Content == command.Content);
        }

        [Fact]
        public async Task Handle_InvalidNote_ThrowsBadRequestException()
        {
            // Arrange
            var command = new CreateNoteCommand
            {
                Title = "",  // Invalid title
                Content = "New Content"
            };

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _handler.Handle(command, CancellationToken.None));
            _mockLogger.Verify(logger => logger.LogWarning(It.IsAny<string>()), Times.Once);
        }
    }
}
