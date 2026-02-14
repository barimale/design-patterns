using EventVisitator;
using EventVisitator.Events;
using EventVisitator.Services;
using Prototype;
using ProxyProperties;
using System.Collections;
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
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();
            var layer1 = new NeuronLayer(3);
            var layer2 = new NeuronLayer(4);

            neuron1.ConnectTo(neuron2);

            neuron1.ConnectTo(layer1);
            layer2.ConnectTo(neuron1);
            layer1.ConnectTo(layer2);

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

            var hero = new Character
            {
                Name = "Arthas",
                Stats = new Stats { Strength = 10, Agility = 5, Intelligence = 3 },
                Inventory = new List<Item>
                {
                    new Item { Name = "Sword", Power = 15 },
                    new Item { Name = "Shield", Power = 8 }
                },
                Skills = new List<string> { "Slash", "Block" }
            };

            var clone = (Character)hero.Clone();
            clone.Name = "Dark Arthas";
            clone.Stats.Strength = 20;
            clone.Inventory[0].Power = 999;
            clone.Skills.Add("Dark Slash");

            Console.WriteLine("hero: ");
            Console.WriteLine(JsonSerializer.Serialize(hero));

            Console.WriteLine("clone: ");
            Console.WriteLine(JsonSerializer.Serialize(clone));

            Console.ReadLine();
        }
    }
}
