using ProxyProperties.Model;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class ProxyProperties : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public ProxyProperties(ITestOutputHelper output)
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
            var creature = new Creature();
            creature.Agility = 10;

            // when
            creature.Agility = 12;

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
