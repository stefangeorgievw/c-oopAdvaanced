using Solid_exercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_exercise.Models
{
    public class Logger:ILogger
    {
        IEnumerable<IAppender> appenders;

        public Logger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        IReadOnlyCollection<IAppender> ILogger.Appenders =>(IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (appender.Level <= error.Level)
                {
                    appender.Append(error);
                }
            }
        }
    }
}
