using HealthyTeethAPI.Helpers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthyTeethAPI.Hubs
{
    public class MainHub : Hub
    {
        public static ConcurrentDictionary<string, string> ConnectedUsers = new ConcurrentDictionary<string, string>();

        public override Task OnConnectedAsync()
        {
            var context = this.Context.GetHttpContext();
            var userName = context.User.Identity.Name;
            var roleName = context.User.FindFirst(ClaimsIdentity.DefaultRoleClaimType).Value;

            ConnectedUsers.TryAdd(userName, Context.ConnectionId);
            AddGroupsToClient(userName, roleName);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(System.Exception exception)
        {
            var context = this.Context.GetHttpContext();
            var userName = context.User.Identity.Name;
            string temp;
            ConnectedUsers.TryRemove(userName, out temp);
            return base.OnDisconnectedAsync(exception);
        }

        private void AddGroupsToClient(string userName, string roleName)
        {
            if (roleName == "Доктор")
            {
                string connectionId;
                ConnectedUsers.TryGetValue(userName, out connectionId);
                Groups.AddToGroupAsync(connectionId, SignalRGroups.doctors_group);
            }
            else if (roleName == "Администратор")
            {
                string connectionId;
                ConnectedUsers.TryGetValue(userName, out connectionId);
                Groups.AddToGroupAsync(connectionId, SignalRGroups.admins_group);
            }
        }
    }
}
