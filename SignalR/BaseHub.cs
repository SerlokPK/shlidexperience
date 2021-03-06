﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalR
{
    public class BaseHub : Hub
    {
        private readonly string _defaultGroupName = "HubUsers";

        public async Task BroadcastMessage(string methodName, object[] parameters)
        {
            await Clients.All.SendAsync(methodName, parameters);
        }

        public async Task SendToCaller(string methodName, object[] parameters)
        {
            await Clients.Caller.SendAsync(methodName, parameters);
        }

        public async Task SendToOthers(string methodName, object[] parameters)
        {
            await Clients.Others.SendAsync(methodName, parameters);
        }

        public async Task SendToGroup(string groupName, string methodName, object[] parameters)
        {
            await Clients.Group(groupName).SendAsync(methodName, parameters);
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
