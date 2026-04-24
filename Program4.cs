using System;
using System.Collections.Generic;

class Transaction
{
    public string Id;
    public double Amount;

    public Transaction(string id, double amt)
    {
        Id = id;
        Amount = amt;
    }
}

class BankingSystem
{
    List<Transaction> history = new List<Transaction>();
    Dictionary<string, double> accounts = new Dictionary<string, double>();
    Queue<Transaction> pending = new Queue<Transaction>();
    Stack<Transaction> rollback = new Stack<Transaction>();
    HashSet<string> ids = new HashSet<string>();

    public void AddTransaction()
    {
        Console.Write("Enter Transaction ID: ");
        string id = Console.ReadLine()!;

        if (!ids.Add(id))
        {
            Console.WriteLine("Duplicate Transaction!");
            return;
        }

        Console.Write("Enter Amount: ");
        double amt = double.Parse(Console.ReadLine()!);

        Transaction t = new Transaction(id, amt);
        pending.Enqueue(t);
        history.Add(t);

        Console.WriteLine("Transaction Added!");
    }

    public void ProcessTransaction()
    {
        if (pending.Count > 0)
        {
            var t = pending.Dequeue();
            rollback.Push(t);
            Console.WriteLine($"Processed: {t.Id}");
        }
    }

    public void Rollback()
    {
        if (rollback.Count > 0)
        {
            var t = rollback.Pop();
            Console.WriteLine($"Rolled back: {t.Id}");
        }
    }
}

class Program
{
    static void Main()
    {
        BankingSystem bs = new BankingSystem();

        bs.AddTransaction();
        bs.ProcessTransaction();
        bs.Rollback();
    }
}