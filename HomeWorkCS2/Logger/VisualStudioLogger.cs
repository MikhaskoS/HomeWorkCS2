namespace MkGame.Log
{
    // Вывод log информации в студии
    public class VisualStudioLogger : DebugLogger
    {
        public override void Log(string Message, string Category)
        {
            System.Diagnostics.Debug.WriteLine($">>>>>>>{Message}", Category);
        }

        public override void Log(string Message)
        {
            System.Diagnostics.Debug.WriteLine($">>>>>>>{Message}");
        }
    }
}
