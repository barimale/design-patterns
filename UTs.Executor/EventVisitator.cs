using ChainOfResponsabilities;
using ChainOfResponsabilities.Model;
using EventVisitator;
using EventVisitator.Events;
using EventVisitator.Services;
using NeuronApp;

namespace UTs.Executor
{
    public class EventVisitator
    {
        [Fact]
        public void Execute()
        {
            // given
            var sender = new SmtpNotificationSender();
            var notifier2 = new NotifierService(sender);
            var processor = new EventProcessor(notifier2);

            IEvent ev1 = new UserRegisteredEvent("user@test.com", "barimale");
            IEvent ev2 = new OrderPaidEvent(123, 199.99m);

            // when
            processor.Process(ev1);
            processor.Process(ev2);

            // then
        }
    }
}
