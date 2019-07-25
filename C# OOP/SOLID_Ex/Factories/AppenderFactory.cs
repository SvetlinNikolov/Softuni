using Logger.Exceptions;
using Logger.Models.Appenders;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.Files;

using System;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelStr)
        {
            Level level;

            bool isParsed = Enum.TryParse<Level>(levelStr, out level);

            if (!isParsed)
            {
                throw new InvalidLevelTypeException();
            }

            ILayout layout = this.layoutFactory.GetLayout(layoutType);

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile();
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidAppenderTypeException();
            }

            return appender;
        }
    }
}
