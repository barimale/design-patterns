using Visitator;

public interface IServiceItem 
{ 
    void Accept(IVisitor visitor); 
}