using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.SignalR.Client;
using PrivateChat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateChat.Services
{
    public class HubProcessor : IHubProcessor
    {

        public async Task SendMessageAsync(HubConnection hubConnection, string username, string message)
        {
            if (hubConnection != null)
            {
                await hubConnection.SendAsync("SendMessage", username, message);
            }
        }

        public bool IsConnected(HubConnection hubConnection)
        {
            return hubConnection?.State == HubConnectionState.Connected;
        }

    }
}
