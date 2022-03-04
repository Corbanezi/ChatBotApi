using Microsoft.AspNetCore.SignalR;

namespace ChatBotTeste
{
    public class chat : Hub
    {
        public void NewMessage(string userName, string message) 
        {
            Clients.All.SendAsync("newMessage", userName, message);
        }

    }
}
