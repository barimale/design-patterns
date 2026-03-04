using PrototypeAndCollectingParameter.Factory;
using PrototypeAndCollectingParameter.Factory.Builders.Model;
using PrototypeAndCollectingParameter.Services;
using System.Text.Json;

namespace UTs.Executor
{
    public class PrototypeAndBuildersAndCollectingParameter
    {
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
            Console.WriteLine("hero: ");
            Console.WriteLine(JsonSerializer.Serialize(hero));

            Console.WriteLine("newHero: ");
            Console.WriteLine(JsonSerializer.Serialize(newHero));

            Console.WriteLine("clone: ");
            Console.WriteLine(JsonSerializer.Serialize(cloned));
        }
    }
}
