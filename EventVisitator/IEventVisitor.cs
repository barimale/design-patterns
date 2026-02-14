using EventVisitator.Events;

namespace EventVisitator
{
    public interface IEventVisitor
    {
        void Visit(UserRegisteredEvent e);
        void Visit(OrderPaidEvent e);
        // kolejne typy zdarzeń dopisujesz jako kolejne metody
    }

}
