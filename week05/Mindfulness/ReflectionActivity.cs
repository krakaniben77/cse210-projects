using System;

public class ReflectionActivity : Activity
{

    private List<string> _prompts= new List<string>()
    {
       " Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
    };

    private List<string> _questions= new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
    };

    public ReflectionActivity()
        : base("Reflection Activity", "Ths activity will help you reflect on times you showed strngth.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random r = new Random();
        string prompt = _prompts[r.Next(_prompts.Count)];

        Console.WriteLine($"Consider the followig prompt:");
        Console.WriteLine($"\n----{prompt}-----");
        Console.WriteLine($"When you have somthing in mind, press Enter.");
        Console.ReadLine(); 

        Console.WriteLine("Now think deeply about each of the following questions.");
        ShowSpinner(3);

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            string q = _questions[r.Next(_questions.Count)];
            Console.WriteLine($"\n {q}");
            ShowSpinner(5);
        }
        DisplayEndingMessage();

        

    }
}