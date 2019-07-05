using Core.Constants;
using System;

namespace Core.Lib
{
    public class CsvLogger
    {
        #region [Declarations]

        private nk.logger.csv.Logger csvLogger;

        #endregion [Declarations]

        /// <summary>
        /// Initiate an instance of Logger class.
        /// </summary>
        public CsvLogger()
        {
            var config = new nk.logger.csv.LoggerConfig();

            config.SetDateTimeFormat(Config.Logger.DateFormat)
                .SetFileName(Config.Logger.FileName)
                .SetRelativePath(Config.Logger.RelativePath)
                .SetReplacementValue(Config.Logger.ReplacementValue);

            csvLogger = new nk.logger.csv.Logger(config);
        }

        #region [Public Logger functions]

        #region [Exception Logs]

        /// <summary>
        /// Log an <see cref="Exception"/> as DEBUG
        /// </summary>
        /// <param name="ex"></param>
        public void Debug(Exception ex) => csvLogger.Debug(ex);

        /// <summary>
        /// Log an <see cref="Exception"/> as ERROR
        /// </summary>
        /// <param name="ex"></param>
        public void Error(Exception ex) => csvLogger.Error(ex);

        /// <summary>
        /// Log an <see cref="Exception"/> as Fatal
        /// </summary>
        /// <param name="ex"></param>
        public void Fatal(Exception ex) => csvLogger.Fatal(ex);

        #endregion [Exception Logs]

        #region [Error message logs]

        /// <summary>
        /// Log a DEBUG message
        /// </summary>
        /// <param name="text">Message</param>
        public void Debug(string text) => csvLogger.Debug(text);

        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Error(string text) => csvLogger.Error(text);

        /// <summary>
        /// Log a FATAL ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Fatal(string text) => csvLogger.Fatal(text);

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text">Message</param>
        public void Info(string text) => csvLogger.Info(text);

        /// <summary>
        /// Log a TRACE message
        /// </summary>
        /// <param name="text">Message</param>
        public void Trace(string text) => csvLogger.Trace(text);

        /// <summary>
        /// Log a WARNING message
        /// </summary>
        /// <param name="text">Message</param>
        public void Warning(string text) => csvLogger.Warning(text);

        #endregion [Error message logs]

        #endregion [Public Logger functions]
    }
}
