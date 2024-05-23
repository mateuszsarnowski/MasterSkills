using MasterSkills.BlazorSpa.Contracts;
using MasterSkills.BlazorSpa.Models.Authentication;
using Microsoft.AspNetCore.Components;

namespace MasterSkills.BlazorSpa.Pages.Authentication
{
    public partial class Login : ComponentBase
    {
        public LoginVM Model { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject] private IAuthenticationServices AuthenticationService { get; set; }

        public Login()
        {

        }

        protected override void OnInitialized()
        {
            Model = new LoginVM();
        }

        protected async Task HandleLogin()
        {
            if (await AuthenticationService.AuthenticateAsync(Model.Email, Model.Password))
            {
                NavigationManager.NavigateTo("/");
            }
            Message = "Username/password combination unknown";
        }
    }
}
