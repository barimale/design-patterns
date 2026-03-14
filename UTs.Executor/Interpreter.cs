using Composite;
using Interpreter.Model.Parsers;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class Interpreter : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public Interpreter(ITestOutputHelper output)
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
            var parser = new ExpressionParser();

            // when
            string input = "1 + 2 * 10 / 2 - 300";
            var expression = parser.Parse(input);
            int result = expression.Interpret();

            Output.WriteLine($"{input} = {result}");

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
