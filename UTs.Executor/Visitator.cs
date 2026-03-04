using UTs.Executor.BaseUT;
using Visitator;
using Visitator.Elements;
using Visitator.Visitators;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class Visitator : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public Visitator(ITestOutputHelper output)
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
        }
    }
}
