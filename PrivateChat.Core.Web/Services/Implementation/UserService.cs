using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using PrivateChat.Domains;
using PrivateChat.Domains.LocalStorage;
using PrivateChat.Domains.Models;
using PrivateChat.Domains.Responses;
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
        public async Task<Response> Login(LoginCredentials loginCredentials)
        {
            try
            {
                var user = await _userRepository.ValidateCredentials(loginCredentials);
                if (user.Count > 0)
                {
                    var storeUser = _mapper.Map<UserStore>(user.FirstOrDefault());
                    await _localStorage.SetItemAsync("user", storeUser);
                    return new Response()
                    {
                        StatusCode = 200,
                        Message = "Logged in Successfully.",
                        Found = true
                    };
                }
                return new Response()
                {
                    StatusCode = 400,
                    Message = "Your Username or Password is incorrect.",
                    Found = false
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    StatusCode = 500,
                    Message = "Internal Server Error. Please contact the admins.",
                    Found = false
                };
            } 
        }
        public async Task<Response> Register(User newUser)
        {
            try
            {
                if (await _userRepository.IsUserAvailable(newUser))
                {
                    await _userRepository.AddUserToDB(newUser);
                    return new Response()
                    {
                        StatusCode = 200,
                        Message = "New User Created Successfully.",
                        Found = false
                    };
            }
                return new Response()
                {
                    StatusCode = 400,
                    Message = "This user already exists. Please choose a new username.",
                    Found = true
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    StatusCode = 500,
                    Message = "Internal Server Error. Please contact the admins.",
                    Found = false
                };
            }
            
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
