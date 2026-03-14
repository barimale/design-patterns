namespace Command.Model.Invoker
{
    public class CommandManager
    {
        private readonly Stack<ICommand> _history = new();

        public void Execute(ICommand command)
        {
            command.Execute();
            _history.Push(command);
        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                var cmd = _history.Pop();
                cmd.Undo();
            }
        }
    }

}
