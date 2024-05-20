using MasterSkills.Application.Contracts.Persistence;
using MasterSkills.Domain.Entities.Notes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSkills.Application.UnitTests.Mock
{
    public class MockNoteRepository
    {
        public static Mock<INoteRepository> GetMockNotesMockRepository()
        {
            var notes = new List<Note>
            {
                new Note
                {
                    Id = 1,
                    Title = "Test Note 1",
                    Content = "Test Content 1",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Note
                {
                    Id = 2,
                    Title = "Test Note 2",
                    Content = "Test Content 2",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };

            var mockNoteRepository = new Mock<INoteRepository>();
            mockNoteRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(notes);

            //mockNoteRepository.Setup(repo => repo.CreateAsync(It.IsAny<Note>()))
            //    .Returns((Note note) =>
            //    {
            //        notes.Add(note);
            //        return Task.CompletedTask;
            //    });

            return mockNoteRepository;
        }


    }
}
