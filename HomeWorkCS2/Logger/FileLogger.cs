namespace MkGame.Log
{
    public class FileLogger : Logger
    {
        private int _index;
        private readonly string _filePath;

        public FileLogger(string FilePath)
        {
            _filePath = FilePath;
        }

        public override void Log(string Message)
        {
            System.IO.File.AppendAllText(_filePath, $"{_index++}:{Message}\r\n");
        }
    }
}
