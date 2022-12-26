using PrivateChat.Domains;
using PrivateChat.Domains.Models;

namespace PrivateChat.Infrastructure.Repository
{
    public interface IUserRepository
    {
        Task AddUserToDB(User user);
        Task<bool> IsUserAvailable(User user);

        Task<List<User>> ValidateCredentials(LoginCredentials userCredentials);
    }
}
