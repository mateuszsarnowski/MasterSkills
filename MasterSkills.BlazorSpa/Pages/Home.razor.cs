using MasterSkills.BlazorSpa.Contracts;
using MasterSkills.BlazorSpa.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Runtime.CompilerServices;


namespace MasterSkills.BlazorSpa.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IAuthenticationServices AuthenticationServices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
        }

        protected void NavigateToLogin()
        {
            NavigationManager.NavigateTo("/login");
        }

        protected void NavigateToRegister()
        {
            NavigationManager.NavigateTo("/register");
        }
        protected async Task Logout()
        {
            await AuthenticationServices.Logout();
        }

    }
}
