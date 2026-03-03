using EventVisitator;
using EventVisitator.Events;
using EventVisitator.Services;
using Prototype;
using PrototypeAndCollectingParameter;
using ProxyProperties;
using System.Text.Json;
using Visitator;
using Visitator.Elements;
using Visitator.Visitators;
using VisitatorAndOthers;
using static Prototype.CharacterBuilder;

namespace NeuronApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            var hero = CharacterBuilder
                .CreateBuilder()
                .WithName("name")
                .WithStats(new Stats { Strength = 10, Agility = 5, Intelligence = 3 })
                .WithSkills(new List<string> { "Slash", "Block" })
                .WithInventory(new List<Item>
                {
                    new Item { Name = "Sword", Power = 15 },
                    new Item { Name = "Shield", Power = 8 }
                })
                .Build();

            var newHero = CharacterBuilder
                .CreateBuilder()
                .Build();

            var manager = new CPExample();
            manager.SetNameTo(newHero, "Arthas3");
            manager.SetInventoryTo(newHero, new List<Item>
            {
                new Item { Name = "Sword", Power = 150 },
                new Item { Name = "Shield", Power = 80 }
            });
            manager.SetSkillsTo(newHero, new List<string> { "Slash2", "Block21" });
            manager.SetStatsTo(newHero, new Stats { Strength = 110, Agility = 15, Intelligence = 13 });

            var clone = new Character(newHero); // Using copy constructor for deep cloning
            clone.Name = "Dark Arthas";
            clone.Stats.Strength = 20;
            clone.Inventory[0].Power = 999;
            clone.Skills.Add("Dark Slash");

            Console.WriteLine("hero: ");
            Console.WriteLine(JsonSerializer.Serialize(hero));

            Console.WriteLine("newHero: ");
            Console.WriteLine(JsonSerializer.Serialize(newHero));

            Console.WriteLine("clone: ");
            Console.WriteLine(JsonSerializer.Serialize(clone));

            Console.ReadLine();
        }
    }
}
