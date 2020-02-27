namespace MkGame.Log
{
    public abstract class DebugLogger : Logger
    {
        //  Обрати внимание! Абстрактный метод бозового класса в абстрактном наследнике
        //  не нужно переопределять!

        public abstract void Log(string Message, string Category);
    }
}
