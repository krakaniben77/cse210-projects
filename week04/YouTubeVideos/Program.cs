using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        List<Video> videos = new List<Video>();

        Video v1=new Video("Abstraction","Krakani Benjamin", 420);
        v1.AddComment(new Comment("Alice", "Great Explanation"));
        v1.AddComment(new Comment("Tom", "Very Clear and helpful"));
        v1.AddComment(new Comment("Sarah", "Amazing adventure"));
        videos.Add(v1);

        Video v2=new Video("Rafting Adventure in Ghana", "Talented Riders", 360);
        v2.AddComment(new Comment("Bismark", "Just funny bro haha!"));
        v2.AddComment(new Comment("Benjamin", "Ghana is really beautiful"));
        v2.AddComment(new Comment("Bonney J", "Lovely"));
        videos.Add(v2);


        Video v3=new Video("Time with greatest footballer of all time", "Christiano Ronaldo", 510);
        v3.AddComment(new Comment("Messi", "I am the greatest not you @Christiano Ronaldo"));
        v3.AddComment(new Comment("Krakani", "Really enjoyed this time"));
        v3.AddComment(new Comment("Kopia", "That's the best video of my life"));
        videos.Add(v3);


        foreach (Video video in videos)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment  in video.Comments)
            {
                Console.WriteLine($" -{comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }    
}


class Video
{
    public string Title {get; }
    public string Author { get; }
    public int Length { get; }
    public List<Comment> Comments { get; }

    public Video(string title, string author, int length)
    {
        Title=title;
        Author = author;
        Length = length;
        Comments =new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

class Comment
{
    public String Name { get; }
    public string Text { get; }
    
    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}