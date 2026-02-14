using EventVisitator.Events;

namespace EventVisitator.Services
{
    public class NotifierService : IEventVisitor
    {
        private readonly INotificationSender _sender;

        public NotifierService(INotificationSender sender)
        {
            _sender = sender;
        }

        public void Visit(UserRegisteredEvent e)
        {
            var subject = "Welcome!";
            var body = $"Hi {e.UserName}, thanks for registering.";
            _sender.SendEmail(e.Email, subject, body);
        }

        public void Visit(OrderPaidEvent e)
        {
            var subject = $"Order #{e.OrderId} paid";
            var body = $"We received your payment of {e.Amount:C}.";
            // przykładowo e-mail do działu finansów:
            _sender.SendEmail("finance@company.com", subject, body);
        }
    }

}
