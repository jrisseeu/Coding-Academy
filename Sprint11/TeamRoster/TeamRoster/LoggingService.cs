using System;
using System.Collections.Generic;
using System.Text;

namespace TeamRoster {
    class LoggingService {

        private readonly ILogger _logger;
        public LoggingService(ILogger logger) {
            _logger = logger;
        }
        public void Log(string message) {
            _logger.Log(message);
        }


    }
}
