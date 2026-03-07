using EventObserver;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class EventObserver : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public EventObserver(ITestOutputHelper output)
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
            var subject = new Subject();

            var obs1 = new ConsoleObserver("Observer A", subject);
            var obs2 = new ConsoleObserver("Observer B", subject);

            subject.State = 10;
            subject.State = 20;

            // when
            // Odsubskrybowanie
            subject.StateChanged -= obs1.HandleStateChanged;

            subject.State = 30;

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
