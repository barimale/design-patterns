using StrategyAndTemplateMethod;
using StrategyAndTemplateMethod.Model;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class StrategyAndTemplateMethod : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public StrategyAndTemplateMethod(ITestOutputHelper output)
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
            var resolver = new StrategyResolver();

            // when
            resolver.Resolve(StrategyEnum.SIMPLE).Execute();
            resolver.Resolve(StrategyEnum.COMPLEX).Execute();

            // then
        }
    }
}
