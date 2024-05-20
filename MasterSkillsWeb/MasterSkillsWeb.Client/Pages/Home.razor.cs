using MasterSkills.Application.Features.Notes.Queries.Notes.GetAllNotes;
using MasterSkillsWeb.Client.HttpRepository.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MasterSkillsWeb.Client.Pages
{
    public partial class Home
    {
        private List<NoteDto> _notes;

        [Inject]
        public INoteHttpRepository NoteHttpRepository { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var notes = await NoteHttpRepository.GetAllAsync();
            _notes = notes;
        }
    }
}
