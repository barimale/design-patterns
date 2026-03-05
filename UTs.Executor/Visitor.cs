using UTs.Executor.BaseUT;
using Visitor;
using Visitor.Elements;
using Visitor.Visitators;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class Visitor : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public Visitor(ITestOutputHelper output)
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
            List<IServiceItem> services = new List<IServiceItem>
            {
                new ServiceA("URL A"),
                new ServiceB("URL B"),
                new ServiceB("URL C")
            };

            IVisitor notifier = new NotifyManager();

            // when
            foreach (var service in services)
            {
                service.Accept(notifier);
            }

            // then
            _originalOut.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
