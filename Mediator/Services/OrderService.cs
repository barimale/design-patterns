using Mediator.Mediator.Abstraction;

namespace Mediator.Services
{
    public class OrderService
    {
        private readonly IOrderMediator _mediator;

        public OrderService(IOrderMediator mediator)
        {
            _mediator = mediator;
        }

        public void Create(int userId, decimal amount)
        {
            _mediator.CreateOrder(userId, amount);
        }
    }

}
