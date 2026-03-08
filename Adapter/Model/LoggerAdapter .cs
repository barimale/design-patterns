namespace Adapter.Model
{
    public class LoggerAdapter : INewLogger
    {
        private readonly OldLogger _adaptee;

        public LoggerAdapter(OldLogger oldLogger)
        {
            _adaptee = oldLogger;
        }

        public void LogInfo(string message)
        {
            _adaptee.Write($"INFO: {message}");
        }

        public void LogError(string message)
        {
            _adaptee.Write($"ERROR: {message}");
        }
    }

}
