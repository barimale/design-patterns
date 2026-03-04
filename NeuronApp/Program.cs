using ChainOfResponsabilities;
using ChainOfResponsabilities.Model;
using EventVisitator;
using EventVisitator.Events;
using EventVisitator.Services;
using PrototypeAndCollectingParameter.Factory;
using PrototypeAndCollectingParameter.Factory.Builders.Model;
using PrototypeAndCollectingParameter.Services;
using ProxyProperties.Model;
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
                .WithStats(new Stats { Strength = 10, Agility = 5, Intelligence = 3 })
                .WithSkills(new List<string> { "Slash", "Block" })
                .WithInventory(new List<Item>
                {
                    DataFactory.CreateItemBuilder().WithName("Sword").WithPower(15).Build(),
                    DataFactory.CreateItemBuilder().WithName("Shield").WithPower(8).Build(),
                })
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
            manager.SetSkillsTo(newHero, new List<string> { "Slash2", "Block21" });
            manager.SetStatsTo(newHero, new Stats { Strength = 110, Agility = 15, Intelligence = 13 });

            var cloned = new Character(newHero); // Using copy constructor for deep cloning
            cloned.Name = "Dark Arthas";
            cloned.Stats.Strength = 20;
            cloned.Inventory[0].Power = 999;
            cloned.Skills.Add("Dark Slash");

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
