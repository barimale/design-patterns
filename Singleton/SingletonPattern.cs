namespace Singleton
{
    public sealed class SingletonPattern
    {
        private static readonly System.Lazy<SingletonPattern> _instance =
            new(() => new SingletonPattern());

        public static SingletonPattern Instance => _instance.Value;

        public string? Data { get; set; }

        private SingletonPattern() 
        {
            // intentionally left blank
        }
    }
}
