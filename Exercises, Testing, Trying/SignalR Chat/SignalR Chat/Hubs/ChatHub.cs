namespace SignalR_Chat.Hubs
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.SignalR;
    using System.Security.Claims;

    public class ChatHub:Hub
    {

        public async Task SendMessage(string message)
        {
            var user = Context.User.Identity.Name;
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    

    }
}
