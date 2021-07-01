using System;

namespace TeamRoster {
    class Program {
        static void Main(string[] args) {

            ILogger logFile = new FileLogger();
            LoggingService aLog = new LoggingService(logFile);
            TeamRosterController exec = new TeamRosterController(aLog);
        }
    }
}
