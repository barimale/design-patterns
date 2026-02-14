namespace EventVisitator.Events
{
    public interface IEvent
    {
        void Accept(IEventVisitor visitor);
    }

}
