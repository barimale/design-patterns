using ProxyProperties.Model;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;
using PropertyProvider = ProxyProperties.PropertySettings.PropertyProvider;
using PropertyProviderSettings = ProxyProperties.PropertySettings.PropertyProviderSettings;

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
            var settings = new PropertyProviderSettings
            {
                ConnectionString = "ORACLE DB CONNECTION STRING"
            };
            PropertyProvider.SetPropertyProviderSettings(settings);

            // when
            var creature = new Creature();
            creature.Agility = 12;
            creature.Inteligence = "15";
            var agility = creature.Agility;
            var inteligence = creature.Inteligence;

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
