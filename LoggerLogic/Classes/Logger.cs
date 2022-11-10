using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.LoggerLogic.Interfaces;

namespace Logger.LoggerLogic.Classes
{
    /// <summary>
    /// Console _logger that has three log types.
    /// </summary>
    internal class Logger : ILogger
    {
        private static Logger? instance;
        private static StringBuilder? allRecordsOfTheSession;

        private Logger()
        {
        }

        /// <summary>
        /// Get _logger sample(singleton).
        /// </summary>
        /// <returns>Singleton _logger sample.</returns>
        public static Logger GetLogger()
        {
            if (instance == null)
            {
                instance = new Logger();
                allRecordsOfTheSession = new StringBuilder(string.Empty);
            }

            return instance;
        }

        /// <inheritdoc/>
        public string GetAllLogs()
        {
            return allRecordsOfTheSession == null ? string.Empty : allRecordsOfTheSession.ToString();
        }

        /// <summary>
        /// Print in console _logger info and writes it in a file.
        /// </summary>
        /// <param name="result">Result of method execution.</param>
        /// <param name="logType">Enum that describes <see cref="LogType">.</param>.
        public void LogInfo(IResult result, LogType logType)
        {
            var currentLine = $"{DateTime.Now}:{logType}:{result.ErrorMessage}\n";
            Console.Write(currentLine);
            allRecordsOfTheSession!.Append(currentLine);
            FileService.WriteAllInFile(currentLine);
            FileService.DeleteFilesUntilOnlyNewestLeft();
        }
    }
}
