namespace Adapter.Model
{
    public class OldLogger
    {
        // cannot be modified, as it is a third-party library
        public void Write(string text)
        {
            Console.WriteLine($"[OLD LOG] {text}");
        }
    }
}
