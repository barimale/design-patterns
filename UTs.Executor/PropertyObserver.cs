using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class PropertyObserver : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public PropertyObserver(ITestOutputHelper output)
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

            var obs1 = new ConsoleObserver("Observer A");
            var obs2 = new ConsoleObserver("Observer B");

            subject.Attach(obs1);
            subject.Attach(obs2);

            // when
            subject.State = 10;
            subject.State = 20;

            subject.Detach(obs1);

            subject.State = 30;

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
