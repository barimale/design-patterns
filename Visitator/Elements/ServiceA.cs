using Visitor;

namespace Visitor.Elements
{
    public class ServiceA : IServiceItem 
    { 
        public string Title { get; set; } 
        public ServiceA(string title) { Title = title; } 
        public void Accept(IVisitor visitor) 
        { 
            visitor.Visit(this); 
        } 
    }
}
