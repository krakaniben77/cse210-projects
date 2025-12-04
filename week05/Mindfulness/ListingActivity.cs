using System;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<String>()
    {
        "Who are people that you appreciate?",
        "What are personal strength of yours?",
        "Who have you helped this week?",
        "When have you felt peace this month",
        "Who are some of your personal heroes?"
    };


    public ListingActivity()
        : base("Listing Activity", "Ths activity will help you list positive things in your life.")
    {
    }

    public  void Run()
    {
        DisplayStartingMessage();

        Random r = new Random();
        string prompt= _prompts[r.Next(_prompts.Count)];

        Console.WriteLine($"\n----{prompt}----");
        Console.WriteLine("You may begin in...");
        Countdown(5);

        List<string> items = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"You Listed {items.Count} items");

        DisplayEndingMessage();


    }
}