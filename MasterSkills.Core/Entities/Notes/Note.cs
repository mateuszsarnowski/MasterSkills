using MasterSkills.Domain.Common;

namespace MasterSkills.Domain.Entities.Notes
{
    public class Note : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public NoteCategory? NoteCategory { get; set; }
        public int? NoteCategoryId { get; set; }

    }
}
