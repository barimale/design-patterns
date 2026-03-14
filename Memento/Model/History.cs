namespace Memento.Model
{
    public class History
    {
        private Stack<Memento> _history = new Stack<Memento>();

        public void Backup(Memento memento)
        {
            _history.Push(memento);
        }

        public Memento Undo()
        {
            return _history.Pop();
        }
    }
}
