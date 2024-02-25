using Microsoft.AspNetCore.SignalR;

namespace Blazor8WithRolesAndSignalR.Hubs;

public class NotificationHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync(method: "ReceiveMessage", user, message);
    }
}
