using ProxyPropertiesWithObserver;
using ProxyPropertiesWithObserver.Model;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class ProxyPropertiesWithObserver : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public ProxyPropertiesWithObserver(ITestOutputHelper output)
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
            var connectionString = "Data Source=MyDatabase;Initial Catalog=MyCatalog;Integrated Security=True;";
            var creature = new Creature();
            var obs1 = new ConsoleObserver<int>("Observer A", connectionString, creature.agility);
            var obs2 = new ConsoleObserver<int>("Observer B", connectionString, creature.agility);
            var obs3 = new ConsoleObserver<string>("Observer C", connectionString, creature.inteligence);

            // when
            creature.Agility = 12;
            creature.Inteligence = "SMART";
            var agility = creature.Agility;
            var inteligence = creature.Inteligence;

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
