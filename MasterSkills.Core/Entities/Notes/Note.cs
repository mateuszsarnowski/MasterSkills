using MasterSkills.Domain.Common;

namespace MasterSkills.Domain.Entities.Notes
{
    public class Note : BaseEntity
    {
        public string Title { get; set; }
        public required string Content { get; set; }

    }
}
