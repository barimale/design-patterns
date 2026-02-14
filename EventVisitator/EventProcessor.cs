using EventVisitator.Events;
using EventVisitator.Services;

namespace EventVisitator
{
    public class EventProcessor
    {
        private readonly NotifierService _notifier;

        public EventProcessor(NotifierService notifier)
        {
            _notifier = notifier;
        }

        public void Process(IEvent @event)
        {
            // podwójna dyspozycja: wywołanie zależy od konkretnego typu zdarzenia
            @event.Accept(_notifier);
        }
}



}
