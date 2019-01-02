using System;

namespace Core.Lib
{
    public class Logger
    {
        #region [Declarations]

        private nk.logger.csv.Logger csvLogger;

        #endregion [Declarations]

        /// <summary>
        /// Initiate an instance of Logger class.
        /// </summary>
        /// <param name="dateFormat">Date Time format.</param>
        /// <param name="fileName">Name of the log file. Without extension</param>
        /// <param name="relativePath">Relative path from Base directory.</param>
        /// <param name="replacementValue">Value to replace comma (,) with. Uses semicolon by default.</param>
        public Logger(string dateFormat, string fileName, string relativePath = "", char replacementValue = ';')
        {
            csvLogger = new nk.logger.csv.Logger(dateFormat, fileName, relativePath, replacementValue);
        }

        #region [Public Logger functions]

        #region [Exception Logs]

        /// <summary>
        /// Log an <see cref="Exception"/> as DEBUG
        /// </summary>
        /// <param name="ex"></param>
        public void Debug(Exception ex)
        {
            csvLogger.Debug(ex);
        }

        /// <summary>
        /// Log an <see cref="Exception"/> as ERROR
        /// </summary>
        /// <param name="ex"></param>
        public void Error(Exception ex)
        {
            csvLogger.Error(ex);
        }

        /// <summary>
        /// Log an <see cref="Exception"/> as Fatal
        /// </summary>
        /// <param name="ex"></param>
        public void Fatal(Exception ex)
        {
            csvLogger.Fatal(ex);
        }

        #endregion [Exception Logs]

        #region [Error message logs]

        /// <summary>
        /// Log a DEBUG message
        /// </summary>
        /// <param name="text">Message</param>
        public void Debug(string text)
        {
            csvLogger.Debug(text);
        }

        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Error(string text)
        {
            csvLogger.Error(text);
        }

        /// <summary>
        /// Log a FATAL ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Fatal(string text)
        {
            csvLogger.Fatal(text);
        }

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text">Message</param>
        public void Info(string text)
        {
            csvLogger.Info(text);
        }

        /// <summary>
        /// Log a TRACE message
        /// </summary>
        /// <param name="text">Message</param>
        public void Trace(string text)
        {
            csvLogger.Trace(text);
        }

        /// <summary>
        /// Log a WARNING message
        /// </summary>
        /// <param name="text">Message</param>
        public void Warning(string text)
        {
            csvLogger.Warning(text);
        }

        #endregion [Error message logs]

        #endregion [Public Logger functions]
    }
}
