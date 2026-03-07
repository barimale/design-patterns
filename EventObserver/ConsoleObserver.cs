namespace EventObserver
{
    public class ConsoleObserver
    {
        private readonly string _name;

        public ConsoleObserver(string name, Subject subject)
        {
            _name = name;
            subject.StateChanged += HandleStateChanged;
        }

        public void HandleStateChanged(object sender, int newValue)
        {
            Console.WriteLine($"{_name} otrzymał powiadomienie: nowa wartość = {newValue}");
        }
    }
}
