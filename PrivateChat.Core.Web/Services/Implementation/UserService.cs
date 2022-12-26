using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using PrivateChat.Domains;
using PrivateChat.Domains.LocalStorage;
using PrivateChat.Domains.Models;
using PrivateChat.Infrastructure.Repository;

namespace PrivateChat.Core.Web.Services
{
    public class UserService : IUserService
    {   
        private readonly IUserRepository _userRepository;
        private ILocalStorageService _localStorage;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, ILocalStorageService localStorage, IMapper mapper)
        {
            _userRepository = userRepository;
            _localStorage = localStorage;
            _mapper = mapper;
        }
        public async Task Login(LoginCredentials loginCredentials)
        {
            var user = await _userRepository.ValidateCredentials(loginCredentials);
            if (user.Count>0)
            {
                var storeUser = _mapper.Map<UserStore>(user.FirstOrDefault());
                await _localStorage.SetItemAsync("user", storeUser);
            }
        }
        public async Task Register(User newUser)
        {
            if(await _userRepository.IsUserAvailable(newUser))
                await _userRepository.AddUserToDB(newUser);
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("user");
        }

        public async ValueTask<UserStore> GetCurrentUser()
        {   
            var containsUser = await _localStorage.ContainKeyAsync("user");
            if (containsUser)
            {
                return await _localStorage.GetItemAsync<UserStore>("user");
            }
            return null;
        }
    }
}
