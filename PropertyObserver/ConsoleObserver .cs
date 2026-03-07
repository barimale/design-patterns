using PropertyObserver;

public class ConsoleObserver : IObserver
{
    private string _name;

    public ConsoleObserver(string name)
    {
        _name = name;
    }

    public void Update(int newValue)
    {
        Console.WriteLine($"{_name} otrzymał powiadomienie: nowa wartość = {newValue}");
    }
}
