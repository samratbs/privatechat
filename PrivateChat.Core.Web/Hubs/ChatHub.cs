using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;

namespace PrivateChat.Core.Web.Hubs
{
    public class ChatHub:Hub
    {

        public override async Task OnConnectedAsync()
        {
            await SendMessage("", "User Connected");
            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }
    }
}
