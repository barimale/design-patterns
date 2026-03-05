using Visitor;

public interface IServiceItem 
{ 
    void Accept(IVisitor visitor); 
}