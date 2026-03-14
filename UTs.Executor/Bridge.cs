using Bridge.Abstraction;
using Bridge.Model.Colors;
using Bridge.Model.Shapes;
using Composite;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class Bridge : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public Bridge(ITestOutputHelper output)
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
            Shape redCircle = new Circle(new RedColor());
            Shape blueSquare = new Square(new BlueColor());

            // when
            redCircle.Draw();
            blueSquare.Draw();

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
