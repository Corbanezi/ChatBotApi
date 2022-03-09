using Microsoft.AspNetCore.SignalR;

namespace ChatBotTeste
{
    public class chat : Hub
    {
        public void NewMessage(string userName, string message) 
        {
            Clients.All.SendAsync("newMessage", userName, message);
        }

        public void NewUser(string userName)
        {
            Clients.All.SendAsync("newUser", userName);
        }
    }
}
