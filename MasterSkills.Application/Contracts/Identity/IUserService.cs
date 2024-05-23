using MasterSkills.Application.Models.Identity;

namespace MasterSkills.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetUsers ();
        Task<User> GetUser (string userId);
    }
}
