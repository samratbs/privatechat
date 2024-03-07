using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using PrivateChat.Domains;

namespace PrivateChat.Server.Hubs
{
    public class ChatHub:Hub
    {

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
