using Visitor;
using Visitor.Elements;

namespace Visitor.Visitators
{
    public class NotifyManager : IVisitor 
    {
        // instancje serwisów, które będą odwiedzane
        public void Visit(ServiceB s) 
        { 
            Console.WriteLine($"<p>{s.Text}</p>"); 
        } 
        public void Visit(ServiceA s) 
        { 
            Console.WriteLine($"<h1>{s.Title}</h1>"); 
        } 
    }
}
