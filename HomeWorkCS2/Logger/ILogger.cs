namespace MkGame.Log
{
    public interface ILogger
    {
        void Log(string Message);
        void LogError(string Message);
        void LogInformation(string Message);
        void LogWarning(string Message);
    }
}