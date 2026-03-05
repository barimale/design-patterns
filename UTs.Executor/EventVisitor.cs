using EventVisitor;
using EventVisitor.Events;
using EventVisitor.Services;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class EventVisitor : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public EventVisitor(ITestOutputHelper output)
            : base(output)
        {
            _originalOut = Console.Out;
            _redirectWriter = new TestOutputTextWriter(output);
            Console.SetOut(_redirectWriter);
        }

        [Fact]
        public void Execute()
        {
            // given
            var sender = new SmtpNotificationSender();
            var notifier2 = new NotifierService(sender);
            var processor = new EventProcessor(notifier2);

            IEvent ev1 = new UserRegisteredEvent("user@test.com", "barimale");
            IEvent ev2 = new OrderPaidEvent(123111222, 199.99m);

            var evs = new List<IEvent> { ev1, ev2 };

            // when
            foreach (var ev in evs)
            {
                processor.Process(ev);
            }

            // then
            _originalOut.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
