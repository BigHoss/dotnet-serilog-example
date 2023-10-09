using System.Runtime.CompilerServices;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace example.api.Extensions;

public static partial class LoggerExtensions
{
    private const int GeneralRange = 11100;

    public static IDisposable? BeginMethodScope(this ILogger logger,
        Dictionary<string, object?>? parameters = null,
        [CallerMemberName] string methodName = "")
    {
        parameters ??= new();

        parameters.Add("MethodName", methodName);
        return logger.BeginScope(parameters);
    }

    [LoggerMessage(Level = LogLevel.Trace, EventId = GeneralRange + 0, Message = "method start")]
    public static partial void TraceStart(this ILogger logger);

    [LoggerMessage(Level = LogLevel.Trace, EventId = GeneralRange + 1, Message = "method end")]
    public static partial void TraceEnd(this ILogger logger);
}
