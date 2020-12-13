using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalR
{
    public class BaseHub : Hub
    {
        private readonly string _defaultGroupName = "HubUsers";

        public async Task BroadcastMessage(string message, string methodName)
        {
            await Clients.All.SendAsync(methodName, message);
        }

        public async Task SendToCaller(string message, string methodName)
        {
            await Clients.Caller.SendAsync(methodName, message);
        }

        public async Task SendToOthers(string message, string methodName)
        {
            await Clients.Others.SendAsync(methodName, message);
        }

        public async Task SendToGroup(string groupName, string message, string methodName)
        {
            await Clients.Group(groupName).SendAsync(methodName, message);
        }

        public async Task AddUserToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task RemoveUserFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public override async Task OnConnectedAsync()
        {
            await AddUserToGroup(_defaultGroupName);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await RemoveUserFromGroup(_defaultGroupName);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
