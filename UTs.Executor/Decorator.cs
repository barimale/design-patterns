using Composite;
using Decorator.Model;
using Decorator.Model.Abstraction;
using Decorator.Model.Decorators;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class Decorator : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public Decorator(ITestOutputHelper output)
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
            IDrink drink = new Coffee();
            drink = new MilkDecorator(drink);
            drink = new SugarDecorator(drink);

            // when
            Output.WriteLine(drink.GetDescription());
            Output.WriteLine($"Cena: {drink.GetCost()} zł");

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
