using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebForUsers.Models;

namespace WebforUsers.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationContext context;

        public ChatHub(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task SendMessage(string user, string topic, string message)
        {
            SaveMessage(user, topic, message);
            await Clients.User(user).SendAsync("ReceiveMessage", user, topic);
            await Clients.User(Context.User.FindFirst(ClaimTypes.Name).Value).SendAsync("notification", "Message sent successfully");
        }

        private void SaveMessage(string user, string topic, string message)
        {
            User sender = context.Users.FirstOrDefault(u => u.Id.ToString() == Context.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            User receiver = context.Users.FirstOrDefault(u => u.Email == user);
            Message msg = new Message()
            {
                Topic = topic,
                Text = message,
                Received = DateTime.Now,
                SenderUserId = sender.Id,
                SenderUser = sender,
                ReceiverUserId = receiver.Id,
                ReceiverUser = receiver,
            };
            context.Messages.Add(msg);
            context.SaveChanges();
        }
    }
}
