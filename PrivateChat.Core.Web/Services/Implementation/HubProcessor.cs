using Microsoft.AspNetCore.SignalR.Client;
using PrivateChat.Domains;

namespace PrivateChat.Core.Web.Services
{
    public class HubProcessor : IHubProcessor
    {
        public async Task SendMessageAsync(HubConnection hubConnection, Chat chat)
        {
            if (hubConnection != null)
            {
                await hubConnection.SendAsync("SendMessage", chat);
            }
        }

        public bool IsConnected(HubConnection hubConnection)
        {
            return hubConnection?.State == HubConnectionState.Connected;
        }

    }
}
