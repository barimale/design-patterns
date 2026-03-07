namespace Adapter.Model
{
    public class LoggerAdapter : INewLogger
    {
        private readonly OldLogger _oldLogger;

        public LoggerAdapter(OldLogger oldLogger)
        {
            _oldLogger = oldLogger;
        }

        public void LogInfo(string message)
        {
            _oldLogger.Write($"INFO: {message}");
        }

        public void LogError(string message)
        {
            _oldLogger.Write($"ERROR: {message}");
        }
    }

}
