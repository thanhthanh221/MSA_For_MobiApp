using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Notification.Hubs;
using Notification.ViewModel;

namespace Notification.Controllers
{
    [Route("NotificationsService/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> signalrHub;

        public NotificationController(IHubContext<NotificationHub> signalrHub)
        {
            this.signalrHub = signalrHub;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNofiticationAsync()
        {
            await signalrHub.Clients.All.SendAsync("SendNotification","Quang");
            
            return this.Ok("Quang");
        }
    }
}
