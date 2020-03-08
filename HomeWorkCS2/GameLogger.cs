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
        public GameLogger() => Init();

        [Conditional("LOGGINGMODE")]
        private void Init()
        {
            StreamWriter myOutputWriter = new StreamWriter("tracelogger.log", false);
            _myTextListener = new TextWriterTraceListener(myOutputWriter);
            

            Trace.Listeners.Add(_myTextListener);
            // рекомендуется, чтобы не терять информацию в случае критических ошибок
            Trace.AutoFlush = true;  
        }

        [Conditional("LOGGINGMODE")]
        public void Close() => _myTextListener.Close();
    }
}
