using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace ChatBotTeste
{
    public class Chat : Hub
    {

        public static List<Message> Messages;

        public Chat()
        {
            if (Messages == null)
                Messages = new List<Message>();
        }
        public void NewMessage(string userName, string text)
        {
            Clients.All.SendAsync("newMessage", userName, text);
            Messages.Add(new Message()
            {
                UserName = userName,
                Text = text
            });
        }

        public void NewUser(string userName, string connectionId)
        {
            Clients.Client(connectionId).SendAsync("previousMessages", Messages);
            Clients.All.SendAsync("newUser", userName);
        }
    }


    public class Message
    {
        public string UserName { get; set; }   
        public string Text { get; set; }
    }
}
