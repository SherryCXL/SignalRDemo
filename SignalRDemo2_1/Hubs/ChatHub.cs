using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo2_1.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            var group = Context.GetHttpContext().Request.Query["token"];

            string value = !string.IsNullOrEmpty(group.ToString()) ? group.ToString() : "default";

            await Groups.AddToGroupAsync(Context.ConnectionId, value);
            await base.OnConnectedAsync();
        }
    }
}
