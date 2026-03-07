namespace EventObserver
{
    public class Subject
    {
        private int _state;

        // Event informujący o zmianie
        public event EventHandler<int> StateChanged;

        public int State
        {
            get => _state;
            set
            {
                _state = value;
                OnStateChanged(_state);
            }
        }

        protected virtual void OnStateChanged(int newValue)
        {
            StateChanged?.Invoke(this, newValue);
        }
    }
}