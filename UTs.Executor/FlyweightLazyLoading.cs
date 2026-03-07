using FlyweightLazyLoading.Model.Forest;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class FlyweightLazyLoading : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public FlyweightLazyLoading(ITestOutputHelper output)
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
            var forest = new Forest();

            forest.PlantTree(10, 20, "Dąb", "Zielony", "oak.png");
            forest.PlantTree(15, 25, "Dąb", "Zielony", "oak.png");
            forest.PlantTree(50, 80, "Sosna", "Ciemna", "pine.png");

            forest.Draw();

            // when

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
