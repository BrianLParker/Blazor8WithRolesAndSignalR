using System.Security.Claims;
using Blazor8WithRolesAndSignalR.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Blazor8WithRolesAndSignalR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SomeController(IHubContext<NotificationHub> hubContext) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<string>> Index()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await hubContext.Clients.Group(groupName: userId)
                .SendAsync(method: "ReceiveMessage", "Server", "You called Index");

            return Ok( "Hello API World");
        }
    }
}
