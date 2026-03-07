namespace Adapter.Model
{
    public interface INewLogger
    {
        void LogInfo(string message);
        void LogError(string message);
    }

}
