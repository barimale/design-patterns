using ProxyPropertiesWithObserver.PropertySettings.Abstraction;

namespace ProxyPropertiesWithObserver
{
    public class ConsoleObserver<T>
    {
        private readonly string _name;
        private readonly string _connectionString;

        public ConsoleObserver(string name, string connectionString, Property<T> subject)
        {
            _name = name;
            _connectionString = connectionString;
            subject.StateChanged += HandleStateChanged; ;
        }

        private void HandleStateChanged(object? sender, T e)
        {
            Console.WriteLine($"{_name} otrzymał powiadomienie do {_connectionString}: nowa wartość = {e}");
        }
    }
}
