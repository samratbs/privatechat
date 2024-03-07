using AutoMapper;
using Blazored.LocalStorage;
using PrivateChat.Domains;
using PrivateChat.Domains.LocalStorage;
using PrivateChat.Domains.Models;
using PrivateChat.Infrastructure.Repository;

namespace PrivateChat.Core.Web.Services
{
    public class ChatProcessor : IChatProcessor
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;

        public ChatProcessor(IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public async Task<List<Messages>> LoadAllMessages()
        {
           return await _chatRepository.GetAllMessages();
        }

        public async Task SaveMessage(Chat chat)
        {
            var message = _mapper.Map<Messages>(chat);
            await _chatRepository.SaveMessageToDb(message);
        }
    }
}
