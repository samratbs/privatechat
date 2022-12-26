using PrivateChat.Domains;
using PrivateChat.Domains.LocalStorage;
using PrivateChat.Domains.Models;

namespace PrivateChat.Core.Web.Services
{
    public interface IUserService
    {
        Task Login(LoginCredentials loginCredentials);
        Task Register(User newUser);
        ValueTask<UserStore> GetCurrentUser();
        Task Logout();
    }
}
