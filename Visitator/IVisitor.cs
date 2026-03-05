using Visitor.Elements;

namespace Visitor
{
    public interface IVisitor
    {
        void Visit(ServiceB paragraph); 
        void Visit(ServiceA header);
    }
}
