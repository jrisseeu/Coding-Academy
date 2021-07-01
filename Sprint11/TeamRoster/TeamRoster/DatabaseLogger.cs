using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    class DatabaseLogger : ILogger {

        void ILogger.Log(string aMessage) {
            LogMessageToDB(aMessage);
        }

        private void LogMessageToDB(string aMesasge) {
            Console.WriteLine("Method: LogMessageToDB, Text: {0}", aMesasge);
        }

    }
}
