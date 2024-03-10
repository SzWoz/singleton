using System;
using System.Collections.Generic;

public class PrintBuffer
{
    private static PrintBuffer instance;
    private Queue<string> printQueue;

    private PrintBuffer()
    {
        printQueue = new Queue<string>();
    }

    public static PrintBuffer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PrintBuffer();
            }
            return instance;
        }
    }

    public void AddToQueue(string document)
    {
        printQueue.Enqueue(document);
    }

    public string PrintNext()
    {
        if (printQueue.Count > 0)
        {
            return printQueue.Dequeue();
        }
        else
        {
            return "No document to print";
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Testowanie bufora wydruku
        PrintBuffer buffer = PrintBuffer.Instance;
        buffer.AddToQueue("Document1");
        buffer.AddToQueue("Document2");

        Console.WriteLine(buffer.PrintNext()); // Powinno wydrukować "Document1"
        Console.WriteLine(buffer.PrintNext()); // Powinno wydrukować "Document2"
        Console.WriteLine(buffer.PrintNext()); // Powinno wydrukować "No document to print", ponieważ kolejka jest pusta

        Console.ReadLine();
    }
}
