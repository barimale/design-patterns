using ProxyPropertiesWithObserver.PropertySettings.Abstraction;

namespace ProxyPropertiesWithObserver
{
    public class ConsoleObserver<T>
    {
        private readonly string _name;

        public ConsoleObserver(string name, Property<T> subject)
        {
            _name = name;
            subject.StateChanged += HandleStateChanged; ;
        }

        private void HandleStateChanged(object? sender, T e)
        {
            Console.WriteLine($"{_name} otrzymał powiadomienie: nowa wartość = {e}");
        }
    }
}
