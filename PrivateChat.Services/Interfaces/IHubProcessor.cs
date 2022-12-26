using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateChat.Services
{
    public interface IHubProcessor
    {
        Task SendMessageAsync(HubConnection hubConnection, string username, string message);
        bool IsConnected(HubConnection hubConnection);
    }
}
