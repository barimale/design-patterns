using Visitator.Elements;

namespace Visitator
{
    public interface IVisitor
    {
        void Visit(ServiceB paragraph); 
        void Visit(ServiceA header);
    }
}
