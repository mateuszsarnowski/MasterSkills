using System.ComponentModel.DataAnnotations;

namespace MasterSkills.BlazorSpa.Models.Notes
{
    public class NoteVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
