using System.Security.Claims;
using Blazor8WithRolesAndSignalR.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Blazor8WithRolesAndSignalR.Controllers;

[Route(template: "api/[controller]")]
[ApiController]
public class SomeController(IHubContext<NotificationHub> hubContext) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<string>> Index()
    {
        var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        await hubContext.Clients.Group(groupName: userId!)
            .SendAsync(method: "ReceiveMessage", "Server", $"Private message from `{nameof(SomeController)}` to `{HttpContext.User.Identity!.Name}`");
        
        await hubContext.Clients.Group(groupName: "AdministratorsOnly")
            .SendAsync(method: "ReceiveMessage", "AdministratorsOnly", $"`{nameof(SomeController)}` used by `{HttpContext.User.Identity!.Name}`");

        return new JsonResult(value: "Hello API World");
    }
}
