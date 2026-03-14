using Mediator.Services.Abstraction;

namespace Mediator.Services
{
    public class EmailNotificationService : INotificationService
    {
        public void Send(string email, string message)
        {
            Console.WriteLine($"Email do {email}: {message}");
        }
    }
}
