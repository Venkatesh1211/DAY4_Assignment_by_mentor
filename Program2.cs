using System;
using System.Collections.Generic;

class MusicManager
{
    LinkedList<string> playlist = new LinkedList<string>();
    SortedList<int, string> ratings = new SortedList<int, string>();
    SortedDictionary<string, string> artistSongs = new SortedDictionary<string, string>();

    public void AddSong()
    {
        Console.Write("Enter song: ");
        string song = Console.ReadLine()!;
        playlist.AddLast(song);

        Console.Write("Enter rating: ");
        int rating = int.Parse(Console.ReadLine()!);
        ratings[rating] = song;

        Console.Write("Enter artist: ");
        string artist = Console.ReadLine()!;
        artistSongs[artist] = song;

        Console.WriteLine("Song added!");
    }

    public void ShowPlaylist()
    {
        Console.WriteLine("\nPlaylist:");
        foreach (var s in playlist)
            Console.WriteLine(s);
    }

    public void ShowSortedByRating()
    {
        Console.WriteLine("\nSongs by Rating:");
        foreach (var r in ratings)
            Console.WriteLine($"{r.Key} -> {r.Value}");
    }
}

class Program
{
    static void Main()
    {
        MusicManager mm = new MusicManager();

        mm.AddSong();
        mm.ShowPlaylist();
        mm.ShowSortedByRating();
    }
}