using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.POS.Extensions
{
    public static partial class LoggerExtensions
    {
        [LoggerMessage(1, LogLevel.Critical, "An unhandled exception has occured. The application has terminated...")]
        public static partial void LogUnhandledException(this ILogger logger, Exception ex);

        [LoggerMessage(2, LogLevel.Information, "Application has been cancelled...")]
        public static partial void LogApplicationCancelled(this ILogger logger);

        [LoggerMessage(3, LogLevel.Information, "Application is starting...")]
        public static partial void LogApplicationStarting(this ILogger logger);

        [LoggerMessage(4,LogLevel.Information, "Application has started.")]
        public static partial void LogApplicationStarted(this ILogger logger);

        [LoggerMessage(5, LogLevel.Information, "Application is stopping...")]
        public static partial void LogApplicationStopping(this ILogger logger);

        [LoggerMessage(6, LogLevel.Information, "Application has stopped.")]
        public static partial void LogApplicationStopped(this ILogger logger);

        [LoggerMessage(7, LogLevel.Information, "Application is exiting with exit code: {ResultCode} ({ResultCodeAsInt}).")]
        public static partial void LogApplicationExiting(this ILogger logger, ResultCode resultCode, int ResultCodeAsInt);
    }
}
