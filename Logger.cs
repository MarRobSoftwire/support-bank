using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank 
{
    public class SBLogger
    {
        private readonly Logger log;
        private readonly string fileName = "C:\\Users\\marrob\\Documents\\Training\\SupportBank\\SupportBank\\SupportBank.log";
        
        public SBLogger() {
            var config = new LoggingConfiguration();
            var target = new FileTarget
            { 
                FileName = fileName, 
                Layout = @"${longdate} ${level} - ${logger}: ${message}" 
            };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;
            log = LogManager.GetCurrentClassLogger();
        }

        public Logger GetLogger() {
            return log;
        }
    }
}