using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Ffsti.Library.NLog
{
    public class LogHelper
    {
        private Logger logger;
        private LoggingConfiguration _configuration;
        private LogManager _logManager;

        public LogHelper()
        {
        }

        public void Debug(string text)
        {
            Logger logger = LogManager.GetLogger(_configuration.AllTargets[0].Name);
            logger.Debug(text);
        }

        public void Error(string text)
        {
            Logger logger = LogManager.GetLogger(_configuration.AllTargets[0].Name);
            logger.Error(text);
        }

        public ILogger CreateConfiguration<TTargetType>(string name,
            LogLevel minLevel = null,
            LogLevel maxLevel = null,
            string layout = "")
            where TTargetType : TargetWithLayout, new()
        {
            if (_configuration == null)
                _configuration = new LoggingConfiguration();

            if (minLevel == null) minLevel = LogLevel.Debug;
            if (maxLevel == null) maxLevel = LogLevel.Fatal;

            var target = CreateTarget<TTargetType>(name + "Target", layout);
            var rule = CreateRule(target, name + "Rule", minLevel, maxLevel);
            _configuration.LoggingRules.Add(rule);

            LogManager.Configuration = _configuration;

            return LogManager.GetLogger(name);
        }

        private TTargetType CreateTarget<TTargetType>(string targetName, string layout = "")
            where TTargetType : TargetWithLayout, new()
        {
            var target = new TTargetType()
            {
                Name = targetName,
                Layout = layout,
                OptimizeBufferReuse = true
            };
            _configuration.AddTarget(targetName, target);
            
            return target;
        }

        private static LoggingRule CreateRule(Target target,
            string loggerNamePattern,
            LogLevel minLevel,
            LogLevel maxLevel)
        {
            var rule = new LoggingRule(loggerNamePattern, minLevel, maxLevel, target);
            return rule;
        }
    }
}
