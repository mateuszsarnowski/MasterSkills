using MasterSkills.BlazorSpa.Contracts;
using MasterSkills.BlazorSpa.Models.Notes;
using Microsoft.AspNetCore.Components;

namespace MasterSkills.BlazorSpa.Pages.Notes
{
    public partial class Index : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] INoteService NoteService { get; set; }
        public List<NoteVM> Notes { get; private set; }
        public string Message { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Notes = await NoteService.GetNotes();
        }

        private void NavigateToCreateNote()
        {
            NavigationManager.NavigateTo("/notes/create");
        }

        private void NavigateToEditNote(NoteVM note)
        {
            NavigationManager.NavigateTo($"/notes/edit/{note.Id}");
        }

        private void NavigateToDetails(int id)
        {
            NavigationManager.NavigateTo($"/notes/details/{id}");
        }

        private async Task DeleteNoteAsync(int id)
        {
            var response = await NoteService.DeleteNote(id);
            if (response.Success)
            {
                StateHasChanged();
                Message = "Note deleted successfully";
                Notes = await NoteService.GetNotes();
            }
            else
            {
                Message = response.Message;
            }

        }

    }
}
