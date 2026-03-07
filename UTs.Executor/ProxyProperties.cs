using ProxyProperties;
using ProxyProperties.Model;
using ProxyProperties.Properties;
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
            var settings = new PropertyProviderSettings
            {
                ConnectionString = "ORACLE DB CONNECTION STRING"
            };
            PropertyProvider.SetPropertyProviderSettings(settings);

            // when
            var creature = new Creature();
            creature.Agility = 12;
            creature.Inteligence = 15;

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
