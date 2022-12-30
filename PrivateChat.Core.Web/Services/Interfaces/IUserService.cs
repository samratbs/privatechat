using PrivateChat.Domains;
using PrivateChat.Domains.LocalStorage;
using PrivateChat.Domains.Models;
using PrivateChat.Domains.Responses;

namespace PrivateChat.Core.Web.Services
{
    public interface IUserService
    {
        Task<Response> Login(LoginCredentials loginCredentials);
        Task<Response> Register(User newUser);
        ValueTask<UserStore> GetCurrentUser();
        Task Logout();
    }
}
