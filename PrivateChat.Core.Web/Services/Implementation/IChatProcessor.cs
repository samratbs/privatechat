using PrivateChat.Domains;
using PrivateChat.Domains.Models;

namespace PrivateChat.Core.Web.Services;

public interface IChatProcessor
{
    Task<List<Messages>> LoadAllMessages();
    Task SaveMessage(Chat chat);
}
