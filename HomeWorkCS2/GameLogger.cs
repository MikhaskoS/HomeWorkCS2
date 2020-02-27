#define LOGGINGMODE 

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using MkGame.Log;

namespace MkGame
{
    class GameLogger : TraceLoger
    {
        TextWriterTraceListener _myTextListener;
        public GameLogger()
        {
            Init();
        }

        [Conditional("LOGGINGMODE")]
        private void Init()
        {
            StreamWriter myOutputWriter = new StreamWriter("tracelogger.log", false);
            _myTextListener = new TextWriterTraceListener(myOutputWriter);

            Trace.Listeners.Add(_myTextListener);

            Game.InitGameEvent += Game_InitGameEvent;
            Game.LoadGameEvent += Game_LoadGameEvent;
            Game.KeyDownEvent += Game_KeyDownEvent;
        }

        private void Game_KeyDownEvent(KeyEventArgs obj)
        {
            this.LogInformation($"{DateTime.Now} : Нажата клавиша: {obj.KeyCode}");
        }

        private void Game_LoadGameEvent()
        {
            this.LogInformation("Инициализация игры");
        }

        private void Game_InitGameEvent()
        {
            this.LogInformation("Загрузка игры");
        }

        [Conditional("LOGGINGMODE")]
        public void Dispose()
        {
            _myTextListener.Flush();
            _myTextListener.Close();
        }
    }
}
