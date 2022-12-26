using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using PrivateChat.Domains;

namespace PrivateChat.Server.Hubs
{
    public class ChatHub:Hub
    {

        public override async Task OnConnectedAsync()
        {
            var chat = new Chat() { 
                Username = "",
                Message = "User Connected"
            };
            await SendMessage(chat);
            await base.OnConnectedAsync();
        }

        public async Task SendMessage(Chat chat)
        {   
            if(chat.ChatMessages == null)
            {
                chat.ChatMessages = new();
            }
            chat.ChatMessages.Clear();
            await Clients.All.SendAsync("ReceiveMessage", chat);
        }
    }
}
