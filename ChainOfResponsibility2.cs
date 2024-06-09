using System;

enum Severity
{
    INFO,
    WARNING,
    ERROR
}

abstract class LogHandler
{
    protected LogHandler nextLogHandler;

    public LogHandler SetNextHandler(LogHandler handler)
    {
        nextLogHandler = handler;
        return handler;
    }

    public virtual void ProcessLog(Severity severity, string logMessage)
    {
        if (nextLogHandler != null)
        {
            nextLogHandler.ProcessLog(severity, logMessage);
        }
    }
}

class InfoLogHandler : LogHandler
{
    public override void ProcessLog(Severity severity, string logMessage)
    {
        if (severity == Severity.INFO)
        {
            Console.WriteLine("INFO: " + logMessage);
        }
        else
        {
            base.ProcessLog(severity, logMessage);
        }
    }
}

class WarningLogHandler : LogHandler
{
    public override void ProcessLog(Severity severity, string logMessage)
    {
        if (severity == Severity.WARNING)
        {
            Console.WriteLine("WARNING: " + logMessage);
        }
        else
        {
            base.ProcessLog(severity, logMessage);
        }
    }
}

class ErrorLogHandler : LogHandler
{
    public override void ProcessLog(Severity severity, string logMessage)
    {
        if (severity == Severity.ERROR)
        {
            Console.WriteLine("ERROR: " + logMessage);
        }
        else
        {
            base.ProcessLog(severity, logMessage);
        }
    }
}

class Application
{
    static void Main()
    {
        var infoLogger = new InfoLogHandler();
        var warningLogger = new WarningLogHandler();
        var errorLogger = new ErrorLogHandler();

        infoLogger.SetNextHandler(warningLogger).SetNextHandler(errorLogger);

        infoLogger.ProcessLog(Severity.INFO, "This is an informational message.");
        infoLogger.ProcessLog(Severity.WARNING, "This is a warning message.");
        infoLogger.ProcessLog(Severity.ERROR, "This is an error message.");
    }
}
