using System;

abstract class SupportHandler
{
    protected SupportHandler nextSupportHandler;

    public SupportHandler SetNextHandler(SupportHandler handler)
    {
        nextSupportHandler = handler;
        return handler;
    }

    public virtual void ProcessSupportTicket(Ticket ticket)
    {
        if (nextSupportHandler != null)
        {
            nextSupportHandler.ProcessSupportTicket(ticket);
        }
    }
}

class TechSupportHandler : SupportHandler
{
    public override void ProcessSupportTicket(Ticket ticket)
    {
        if (ticket.Category == "technical")
        {
            Console.WriteLine("Processing technical ticket: " + ticket.Details);
        }
        else
        {
            base.ProcessSupportTicket(ticket);
        }
    }
}

class BillingSupportHandler : SupportHandler
{
    public override void ProcessSupportTicket(Ticket ticket)
    {
        if (ticket.Category == "billing")
        {
            Console.WriteLine("Processing billing ticket: " + ticket.Details);
        }
        else
        {
            base.ProcessSupportTicket(ticket);
        }
    }
}

class GeneralSupportHandler : SupportHandler
{
    public override void ProcessSupportTicket(Ticket ticket)
    {
        if (ticket.Category == "general")
        {
            Console.WriteLine("Processing general ticket: " + ticket.Details);
        }
        else
        {
            base.ProcessSupportTicket(ticket);
        }
    }
}

class Ticket
{
    public string Category { get; }
    public string Details { get; }

    public Ticket(string category, string details)
    {
        Category = category;
        Details = details;
    }
}

class User
{
    public Ticket CreateTicket(string category, string details)
    {
        return new Ticket(category, details);
    }

    public void HandleTicket(Ticket ticket, SupportHandler handler)
    {
        handler.ProcessSupportTicket(ticket);
    }
}

class Program
{
    static void Main()
    {
        var techHandler = new TechSupportHandler();
        var billingHandler = new BillingSupportHandler();
        var generalHandler = new GeneralSupportHandler();

        techHandler.SetNextHandler(billingHandler).SetNextHandler(generalHandler);

        var user = new User();

        var ticket1 = user.CreateTicket("technical", "Unable to connect to Wi-Fi.");
        var ticket2 = user.CreateTicket("billing", "Invoice discrepancy question.");
        var ticket3 = user.CreateTicket("general", "Inquiry about new services.");

        user.HandleTicket(ticket1, techHandler);
        user.HandleTicket(ticket2, techHandler);
        user.HandleTicket(ticket3, techHandler);
    }
}
