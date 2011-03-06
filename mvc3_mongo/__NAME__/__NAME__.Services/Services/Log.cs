//-----------------------------------------------------------------------
// <copyright file="Log.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Services
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using log4net;

    /// <summary>
    /// Wrapper over log4net
    /// DEBUG &lt; INFO &lt; WARN &lt; ERROR &lt; FATAL
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Write debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args.</param>
        public static void Debug(string message, params object[] args)
        {
            Debug(null, null, message, args);
        }

        /// <summary>
        /// Write info message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Info(string message, params object[] args)
        {
            Info(null, null, message, args);
        }

        /// <summary>
        /// Write warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Warn(string message, params object[] args)
        {
            Warn(null, null, message, args);
        }

        /// <summary>
        /// Write error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Error(string message, params object[] args)
        {
            Error(null, null, message, args);
        }

        /// <summary>
        /// Write fatal message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Fatal(string message, params object[] args)
        {
            Fatal(null, null, message, args);
        }

        /// <summary>
        /// Write debug message.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Debug(Exception e, string message, params object[] args)
        {
            Debug(null, e, message, args);
        }

        /// <summary>
        /// Write info message.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Info(Exception e, string message, params object[] args)
        {
            Info(null, e, message, args);
        }

        /// <summary>
        /// Write warning message.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Warn(Exception e, string message, params object[] args)
        {
            Warn(null, e, message, args);
        }

        /// <summary>
        /// Write error message.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Error(Exception e, string message, params object[] args)
        {
            Error(null, e, message, args);
        } 

        /// <summary>
        /// Write fatal message.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Fatal(Exception e, string message, params object[] args)
        {
            Fatal(null, e, message, args);
        }

        /// <summary>
        /// Write debug message. 
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <param name="e">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Debug(string loggerName, Exception e, string message, params object[] args)
        { 
            ILog log = GetLog(loggerName);
            string text = String.Format(message, args);
            if (log.IsDebugEnabled)
            {
                if (e != null)
                {
                    log.Debug(text, e);
                }
                else
                {
                    log.Debug(text);
                }
            }
        }

        /// <summary>
        /// Write info message.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <param name="e">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Info(string loggerName, Exception e, string message, params object[] args)
        { 
            ILog log = GetLog(loggerName);
            string text = String.Format(message, args);
            if (log.IsInfoEnabled)
            {
                if (e != null)
                {
                    log.Info(text, e);
                }
                else
                {
                    log.Info(text);
                }
            }
        }

        /// <summary>
        /// Write warning message.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <param name="e">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Warn(string loggerName, Exception e, string message, params object[] args)
        {
            ILog log = GetLog(loggerName);
            string text = String.Format(message, args);
            if (log.IsWarnEnabled)
            {
                if (e != null)
                {
                    log.Warn(text, e);
                }
                else
                {
                    log.Warn(text);
                }
            }
        }

        /// <summary>
        /// Write error message.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <param name="e">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Error(string loggerName, Exception e, string message, params object[] args)
        {
            ILog log = GetLog(loggerName);
            string text = String.Format(message, args);
            if (log.IsErrorEnabled)
            {
                if (e != null)
                {
                    log.Error(text, e);
                }
                else
                {
                    log.Error(text);
                }
            }
        }

        /// <summary>
        /// Write fatal message.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <param name="e">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The optional args</param>
        public static void Fatal(string loggerName, Exception e, string message, params object[] args)
        {
            ILog log = GetLog(loggerName);
            string text = String.Format(message, args);
            if (log.IsFatalEnabled)
            {
                if (e != null)
                {
                    log.Fatal(text, e);
                }
                else
                {
                    log.Fatal(text);
                }
            }
        }
   
        /// <summary>
        /// Gets the log.
        /// </summary>
        /// <param name="logName">Name of the log.</param>
        /// <returns>Logger instance</returns>
        private static ILog GetLog(string logName)
        {
            if (String.IsNullOrWhiteSpace(logName))
            {
                logName = "LOG";
            }        

            ILog logger = LogManager.GetLogger(logName);

            return logger;
        }
    }
}
