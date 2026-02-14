namespace EventVisitator.Events
{
    public class OrderPaidEvent : IEvent
    {
        public int OrderId { get; }
        public decimal Amount { get; }

        public OrderPaidEvent(int orderId, decimal amount)
        {
            OrderId = orderId;
            Amount = amount;
        }

        public void Accept(IEventVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

}
