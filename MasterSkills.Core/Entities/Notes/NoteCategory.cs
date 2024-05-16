using MasterSkills.Domain.Common;

namespace MasterSkills.Domain.Entities.Notes
{
    public class NoteCategory : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
