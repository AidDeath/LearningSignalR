using Microsoft.AspNetCore.SignalR;

namespace LearningSignalR
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("Send", message);
        }

        public async Task Log(string message)
        {
            Console.WriteLine($"Message: {message}");
        }
    }
}
