using NLog;
using System;

namespace MoxIT.Template.Core
{
    public class ConfigNLog
    {
        public static Logger ConfigurationNLog()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var date = DateTime.Now.ToString("MM-dd-yyyy");
            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = $"logs/{date}.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            LogManager.Configuration = config;

            return LogManager.GetCurrentClassLogger();
        }
    }
}
