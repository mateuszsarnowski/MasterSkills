using MasterSkills.Application.Features.Notes.Queries.Notes.GetAllNotes;
using MasterSkillsWeb.Client.HttpRepository.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MasterSkillsWeb.Client.Pages
{
    public partial class Home
    {

        private List<NoteDto> _notes;

        [Inject]
        public INoteHttpRepository NoteHttpRepository { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(5000);
            var notes = await NoteHttpRepository.GetAllAsync();
            _notes = notes;
        }
    }
}
