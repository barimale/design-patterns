using Composite;
using Mediator.Mediator;
using Mediator.Repositories;
using Mediator.Services;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class Mediator : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public Mediator(ITestOutputHelper output)
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
            var userRepo = new InMemoryUserRepository();
            var orderRepo = new InMemoryOrderRepository();
            var notification = new EmailNotificationService();
            var logger = new ConsoleLoggingService();

            var mediator = new OrderMediator(userRepo, orderRepo, notification, logger);
            var orderService = new OrderService(mediator);

            orderService.Create(1, 250.00m);

            // when

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
