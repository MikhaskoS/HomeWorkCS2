using System;
using System.Collections.Generic;

namespace MkGame.Log
{
    public class ListLogger : Logger
    {
        private readonly List<string> _Messages = new List<string>();

        public string[] Messages => _Messages.ToArray();

        // добавление сообщений
        public override void Log(string Message)
        {
            _Messages.Add($"({DateTime.Now}){Message}");
        }
    }
}
