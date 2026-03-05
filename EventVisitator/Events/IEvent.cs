using EventVisitor;

namespace EventVisitor.Events
{
    public interface IEvent
    {
        void Accept(IEventVisitor visitor);
    }

}
