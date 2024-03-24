using System;

interface INewLoggingLibrary
{
    void NewLog(string message);
}

class OldLoggingLibrary
{
    public void LogMessage(string message)
    {
        Console.WriteLine("Log from Old Logging Library: " + message);
    }
}

class Adapter : INewLoggingLibrary
{
    private OldLoggingLibrary oldLibrary;

    public Adapter(OldLoggingLibrary oldLibrary)
    {
        this.oldLibrary = oldLibrary;
    }

    public void NewLog(string message)
    {
        oldLibrary.LogMessage(message);
    }
}

class NewLoggingLibrary : INewLoggingLibrary
{
    public void NewLog(string message)
    {
        Console.WriteLine("Log from New Logging Library: " + message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        OldLoggingLibrary oldLibrary = new OldLoggingLibrary();
        Adapter adapter = new Adapter(oldLibrary);

        adapter.NewLog("Message logged by adapter");
    }
}
