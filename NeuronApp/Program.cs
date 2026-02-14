using ProxyProperties;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
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


            List<IElement> document = new List<IElement> 
            { 
                new Header("Witaj w Visitor Pattern"),
                new Paragraph("To jest przykładowy paragraf."), 
                new Paragraph("Visitor pozwala dodawać operacje bez modyfikacji klas.") 
            };
            
            IVisitor renderer = new HtmlRenderer(); 
            
            foreach (var element in document) 
            { 
                element.Accept(renderer); 
            }

            Console.ReadLine();
        }
    }
}
