namespace Visitator.Elements
{
    public class ServiceB : IServiceItem 
    { 
        public string Text { get; set; } 
        public ServiceB(string text) { Text = text; } 
        public void Accept(IVisitor visitor) 
        { 
            visitor.Visit(this); 
        } 
    }
}
