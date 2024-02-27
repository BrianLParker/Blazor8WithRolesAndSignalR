using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Blazor8WithRolesAndSignalR.Hubs;

public class NotificationHub(ILogger<NotificationHub> logger) : Hub
{
    public override async Task OnConnectedAsync()
    {
        var userId = Context.UserIdentifier;
        await Groups.AddToGroupAsync(Context.ConnectionId, userId!);

        if (Context.User!.IsInRole(role: "Moderator"))
        {
            logger.LogInformation(message: "Moderator is in the House!");
            await Groups.AddToGroupAsync(connectionId: Context.ConnectionId, groupName: "ModeratorsOnly");
        }

        if (Context.User!.IsInRole(role: "Administrator"))
        {
            logger.LogInformation(message: "Administrator is in the House!");
            await Groups.AddToGroupAsync(connectionId: Context.ConnectionId, groupName: "AdministratorsOnly");

        }
        else // so admin can sneak onto server...
        {
            await Clients.Group(groupName: "ModeratorsOnly")
                .SendAsync(method: "ReceiveMessage", "ModeratorsOnly", $"User {Context.User.Identity!.Name} connected.");
        }
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var user = Context.User;
        if (user != null)
        {
            await Clients.Group(groupName: "ModeratorsOnly")
                .SendAsync(method: "ReceiveMessage", "Server", $"User {Context.User!.Identity!.Name} disconnected.");

        }
        await base.OnDisconnectedAsync(exception);
    }

    [Authorize]
    public async Task SendMessage(string user, string message) => await Clients.All.SendAsync(method: "ReceiveMessage", user, message);
}
