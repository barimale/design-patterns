using PropertyObserver.Abstraction;
namespace PropertyObserver
{
    public class Subject
    {
        private List<IObserver> observers = new List<IObserver>();
        private int _state;

        public int State
        {
            get => _state;
            set
            {
                _state = value;
                NotifyObservers();
            }
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        private void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(_state);
            }
        }
    }
}