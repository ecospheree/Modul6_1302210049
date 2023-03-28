// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using System.Diagnostics;
using System.Net.WebSockets;

public class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadVideos;
    public string Username;

    public SayaTubeUser(string username)
    {
        Username = username;
        id = new Random().Next(10000, 100000);
        uploadVideos= new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        return uploadVideos.Count();
    }

    public void AddVideo(SayaTubeVideo video)
    {
        uploadVideos.Add(video);
    }

    public void PrintAllVideoPlayCount(int count)
    {
        Console.WriteLine("username : " + Username);
        for (int i = 0; i < uploadVideos.Count; i++)
        {
            Console.WriteLine(" Video " + (i + 1) + "judul " + uploadVideos[i].title);
        }
    }
}


public class SayaTubeVideo
{
    private int id;
    public string title;
    private int playCount;

    public SayaTubeVideo(string t)
    {
        this.title = t;
        Random Rx = new Random();
        id = Rx.Next(10000, 99999);
        this.playCount = 0;
        Debug.Assert(t.Length < 100 && t != null);
    }

    public void IncreasePlayCount(int pc)
    {
        try
        {
            this.playCount += pc;
        }
        catch(OverflowException error)
        {
            Console.WriteLine(error.Message);
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("id : " + this.id);
        Console.WriteLine("title : " + this.title);
        Console.WriteLine("playCount : " + this.playCount);
    }

    public int GetPlayCount()
    {
        return this.playCount;  
    }

    public static void Main(string[] args)
    {
        SayaTubeVideo video = new SayaTubeVideo(" Review Film bagus oleh - Nabiel ");
        for (int i = 0; i < 1000; i++)
        {
            video.IncreasePlayCount(100);
        }
        video.PrintVideoDetails();
    }
}




