using System;
using System.Runtime.ConstrainedExecution;
using System.Threading;


public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name=name;
        _description=description;
    }

    public void SetDuration(int seconds)
    {
        _duration = seconds;

    }

    public int GetDuration()
    {
        return _duration;
    }

    public virtual void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}Activity.");
        Console.WriteLine(_description);

        Console.Write("How long, in seconds, would you like this session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to Begin...");
        ShowSpinner(4);

    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        ShowSpinner(2);

        Console.WriteLine($"You have completed the {_name} activity");
        Console.WriteLine($"Duration: {_duration} seconds.");
        ShowSpinner(4);

    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames= {"|", "/", "-", "\\"};
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(frames[1]);
            Thread.Sleep(200);
            Console.Write("\b");
            i= (i+1) % frames.Length;
        }
    }

    protected void Countdown(int sec)
    {
        for (int i = sec; i >0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");

        }
    }


    // public abstract void Run();
}