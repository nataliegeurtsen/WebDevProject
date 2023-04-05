using Microsoft.AspNetCore.SignalR;
using WebDevProject.Controllers;
using WebDevProject.Models;

namespace WebDevProject.Hubs
{
    public class ChatHub : Hub
    {
        private readonly MyDbContext _myDbContext;
        public ChatHub(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            if (message.Length > 200)
                message = message.Substring(0, 200);
            if (user.Length > 64)
                user = user.Substring(0, 64);

            _ = Clients.All.SendAsync("ReceiveMessage", user, message);

            AddMessageToDb(new Message(user, message));
        }

        public void AddMessageToDb(Message message)
        {
            _myDbContext.Messages.Add(message);
            _myDbContext.SaveChanges();
            Console.WriteLine($"Message {message.MessageId} added to database");
        }
    }
}