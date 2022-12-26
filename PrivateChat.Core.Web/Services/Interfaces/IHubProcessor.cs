using Microsoft.AspNetCore.SignalR.Client;
using PrivateChat.Domains;

namespace PrivateChat.Core.Web.Services
{
    public interface IHubProcessor
    {
        Task SendMessageAsync(HubConnection hubConnection, Chat chat);
        bool IsConnected(HubConnection hubConnection);
    }
}
