using System;
using System.Collections.Generic;

class TaskManager
{
    Queue<string> tasks = new Queue<string>();
    Stack<string> undo = new Stack<string>();
    List<string> allTasks = new List<string>();
    SortedDictionary<int, string> priority = new SortedDictionary<int, string>();
    HashSet<string> unique = new HashSet<string>();

    public void AddTask()
    {
        Console.Write("Enter task: ");
        string task = Console.ReadLine()!;

        if (!unique.Add(task))
        {
            Console.WriteLine("Duplicate task!");
            return;
        }

        tasks.Enqueue(task);
        allTasks.Add(task);

        Console.Write("Enter priority: ");
        int p = int.Parse(Console.ReadLine()!);
        priority[p] = task;

        Console.WriteLine("Task added!");
    }

    public void ExecuteTask()
    {
        if (tasks.Count > 0)
        {
            string t = tasks.Dequeue();
            undo.Push(t);
            Console.WriteLine($"Executed: {t}");
        }
    }

    public void UndoTask()
    {
        if (undo.Count > 0)
        {
            Console.WriteLine($"Undo: {undo.Pop()}");
        }
    }
}

class Program
{
    static void Main()
    {
        TaskManager tm = new TaskManager();

        tm.AddTask();
        tm.ExecuteTask();
        tm.UndoTask();
    }
}