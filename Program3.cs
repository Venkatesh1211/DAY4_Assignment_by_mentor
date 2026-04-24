using System;
using System.Collections.Generic;

class SocialMedia
{
    List<string> posts = new List<string>();
    Dictionary<string, int> likes = new Dictionary<string, int>();
    HashSet<int> users = new HashSet<int>();
    Stack<string> actions = new Stack<string>();
    Queue<string> notifications = new Queue<string>();

    public void AddPost()
    {
        Console.Write("Enter post: ");
        string post = Console.ReadLine()!;
        posts.Add(post);
        likes[post] = 0;
        Console.WriteLine("Post added!");
    }

    public void LikePost()
    {
        Console.Write("Enter post to like: ");
        string post = Console.ReadLine()!;

        if (likes.ContainsKey(post))
        {
            likes[post]++;
            actions.Push("Liked " + post);
            notifications.Enqueue("New like on post");
            Console.WriteLine("Post liked!");
        }
        else
        {
            Console.WriteLine("Post not found!");
        }
    }

    public void UndoAction()
    {
        if (actions.Count > 0)
        {
            Console.WriteLine("Undo: " + actions.Pop());
        }
    }

    public void ShowNotifications()
    {
        while (notifications.Count > 0)
        {
            Console.WriteLine(notifications.Dequeue());
        }
    }
}

class Program
{
    static void Main()
    {
        SocialMedia sm = new SocialMedia();

        sm.AddPost();
        sm.LikePost();
        sm.UndoAction();
        sm.ShowNotifications();
    }
}