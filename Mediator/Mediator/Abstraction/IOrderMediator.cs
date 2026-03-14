namespace Mediator.Mediator.Abstraction
{
    public interface IOrderMediator
    {
        void CreateOrder(int userId, decimal amount);
    }

}
