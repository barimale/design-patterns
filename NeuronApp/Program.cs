using ChainOfResponsabilities;
using ChainOfResponsabilities.Model;
using EventVisitator;
using EventVisitator.Events;
using EventVisitator.Services;
using PrototypeAndCollectingParameter.Factory;
using PrototypeAndCollectingParameter.Factory.Builders.Model;
using PrototypeAndCollectingParameter.Services;
using ProxyProperties.Model;
using Singleton;
using StrategyAndTemplateMethod;
using StrategyAndTemplateMethod.Model;
using System.Text.Json;
using Visitator;
using Visitator.Elements;
using Visitator.Visitators;
using VisitatorAndOthers;

namespace NeuronApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pipeline = new PipelineFacade();
            pipeline.Initialize();
            pipeline.Run(new DummyInput { Data = "Sample data" }).Wait();

            // -----------------------------------

            var singleton = SingletonPattern.Instance;
            singleton.Data = "Hello, Singleton!";
            Console.WriteLine(singleton.Data);

            var second = SingletonPattern.Instance;
            Console.WriteLine(second.Data);

            second.Data = "Changed data";
            Console.WriteLine(second.Data);
            Console.WriteLine(singleton.Data);

            // -----------------------------------

            var resolver = new StrategyResolver();
            resolver.Resolve(StrategyEnum.SIMPLE).Execute();
            resolver.Resolve(StrategyEnum.COMPLEX).Execute();

            // -----------------------------------
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();
            var layer1 = new NeuronLayer(3);
            var layer2 = new NeuronLayer(4);

            neuron1.ConnectTo(neuron2);

            neuron2.ConnectTo(layer1);
            layer1.ConnectTo(layer2);
            //layer2.ConnectTo(neuron1);

            // ----------------------------------
            var creature = new Creature();
            creature.Agility = 12;


            List<IServiceItem> services = new List<IServiceItem> 
            { 
                new ServiceA("URL A"),
                new ServiceB("URL B"), 
                new ServiceB("URL C") 
            };
            
            IVisitor notifier = new NotifyManager(); 
            
            foreach (var service in services) 
            {
                service.Accept(notifier); 
            }

            var sender = new SmtpNotificationSender();
            var notifier2 = new NotifierService(sender);
            var processor = new EventProcessor(notifier2);

            IEvent ev1 = new UserRegisteredEvent("user@test.com", "Mateusz");
            IEvent ev2 = new OrderPaidEvent(123, 199.99m);

            processor.Process(ev1);
            processor.Process(ev2);

            // ----------------------------------

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

            var cloned = new Character(newHero); // Using copy constructor for deep cloning
            cloned.Name = "Dark Arthas";
            cloned.Stats.Strength = 20;
            cloned.Inventory[0].Power = 999;
            cloned.Skills.Add(DataFactory.CreateSkillBuilder().WithName("Dark Slash").Build());

            Console.WriteLine("hero: ");
            Console.WriteLine(JsonSerializer.Serialize(hero));

            Console.WriteLine("newHero: ");
            Console.WriteLine(JsonSerializer.Serialize(newHero));

            Console.WriteLine("clone: ");
            Console.WriteLine(JsonSerializer.Serialize(cloned));

            Console.ReadLine();
        }
    }
}
