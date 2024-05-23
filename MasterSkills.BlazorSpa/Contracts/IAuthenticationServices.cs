namespace MasterSkills.BlazorSpa.Contracts
{
    public interface IAuthenticationServices
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
        Task Logout();

    }
}
