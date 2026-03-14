namespace Mediator.Services.Abstraction
{
    public interface INotificationService
    {
        void Send(string email, string message);
    }
}
