using PrototypeAndBuildersAndCollectingParameter.Factory;
using PrototypeAndBuildersAndCollectingParameter.Factory.Builders.Model;
using PrototypeAndBuildersAndCollectingParameter.Services;
using System.Text.Json;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class PrototypeAndBuildersAndCollectingParameter : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public PrototypeAndBuildersAndCollectingParameter(ITestOutputHelper output)
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
            var hero = DataFactory
                .CreateCharacterBuilder()
                .WithName("name")
                .WithStats(
                    DataFactory.CreateStatsBuilder()
                     .WithStrength(10)
                     .WithAgility(5)
                     .WithIntelligence(3)
                     .Build())
                .WithSkills(
                    DataFactory.CreateSkillBuilder().WithName("Slash").Build(),
                    DataFactory.CreateSkillBuilder().WithName("Block").Build()
                )
                .WithInventory(
                    DataFactory.CreateItemBuilder().WithName("Sword").WithPower(15).Build(),
                    DataFactory.CreateItemBuilder().WithName("Shield").WithPower(8).Build()
                )
                .Build();

            var newHero = DataFactory
                .CreateCharacterBuilder()
                .Build();

            var manager = new CollectingParameterPatternService();
            manager.SetNameTo(newHero, "Arthas3");
            manager.SetInventoryTo(newHero, new List<Item>
            {
                 DataFactory.CreateItemBuilder().WithName("Sword").WithPower(150).Build(),
                 DataFactory.CreateItemBuilder().WithName("Shield").WithPower(80).Build(),
            });
            manager.SetSkillsTo(newHero, new List<Skill> {
                DataFactory.CreateSkillBuilder().WithName("Slas2").Build(),
                DataFactory.CreateSkillBuilder().WithName("Block2").Build()
            });
            manager.SetStatsTo(newHero, DataFactory
                .CreateStatsBuilder()
                .WithIntelligence(11)
                .WithAgility(11)
                .WithStrength(11)
                .Build());

            // when
            var cloned = new Character(newHero); // Using copy constructor for deep cloning
            cloned.Name = "Dark Arthas";
            cloned.Stats.Strength = 20;
            cloned.Inventory[0].Power = 999;
            cloned.Skills.Add(DataFactory.CreateSkillBuilder().WithName("Dark Slash").Build());

            // then
            Output.WriteLine("hero: ");
            Output.WriteLine(JsonSerializer.Serialize(hero));

            Output.WriteLine("newHero: ");
            Output.WriteLine(JsonSerializer.Serialize(newHero));

            Output.WriteLine("clone: ");
            Output.WriteLine(JsonSerializer.Serialize(cloned));
        }
    }
}
