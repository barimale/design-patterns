using Mediator.Services.Abstraction;

namespace Mediator.Services
{
    public class ConsoleLoggingService : ILoggingService
    {
        public void Log(string message)
        {
            Console.WriteLine($"LOG: {message}");
        }
    }
}
