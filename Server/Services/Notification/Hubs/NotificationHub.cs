﻿using Microsoft.AspNetCore.SignalR;

namespace Notification.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("SendNotification", message);
        }
    }
}
