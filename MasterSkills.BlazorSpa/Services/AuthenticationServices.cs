using Blazored.LocalStorage;
using MasterSkills.BlazorSpa.Contracts;
using MasterSkills.BlazorSpa.Providers;
using MasterSkills.BlazorSpa.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace MasterSkills.BlazorSpa.Services
{
    public class AuthenticationServices : BaseHttpService, IAuthenticationServices
    {
        AuthenticationStateProvider _authenticationStateProvider;
        public AuthenticationServices(IClient client,
            ILocalStorageService localStorageService,
            AuthenticationStateProvider authenticationStateProvider) : base(client, localStorageService)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            try
            {
                AuthRequest authenticationRequest = new AuthRequest()
                {
                    Email = email,
                    Password = password
                };

                var authenticationResponse = await _client.LoginAsync(authenticationRequest);

                if (authenticationResponse.Token != string.Empty)
                {
                    await _localStorage.SetItemAsync("token", authenticationResponse.Token);

                    await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Password = password
            };

            var registrationResponse = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(registrationResponse.UserId))
            {
                return true;
            }
            return false;
        }
    }
}
