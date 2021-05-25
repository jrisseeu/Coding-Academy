using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TeamRoster {
    class FileLogger : ILogger {
        void ILogger.Log(string aMessage) {
            LogMessageToFile(aMessage);
        }

        private void LogMessageToFile(string aMessage) {
            Console.WriteLine("Method: LogMessageToFile, Text: {0}", aMessage);

            string fileLocation = "C:\\Coding-Academy.log.txt";

            try {

                StreamWriter write = new StreamWriter(fileLocation, append: true);
                write.WriteLineAsync(aMessage);
                write.Close();

            } catch(Exception e) {
                Console.WriteLine("Failed writing to local log" + e.ToString());

            }

        }
    }


    

}
