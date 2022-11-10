namespace Logger.LoggerLogic.Interfaces
{
    /// <summary>
    /// Logs information in console.
    /// </summary>
    internal interface ILogger
    {
        /// <summary>
        /// Logs information considering result <see cref="IResult"> and logtype <see cref="LogType">.
        /// </summary>
        /// <param name="result">Describes <see cref="IResult">.</param>
        /// <param name="logType">Describes <see cref="LogType">.</param>.
        void LogInfo(IResult result, LogType logType);

        /// <summary>
        /// Gets all logs of the current session writes all in the file.
        /// </summary>
        /// <returns>String that represents all records of the session.</returns>
        string GetAllLogs();
    }
}