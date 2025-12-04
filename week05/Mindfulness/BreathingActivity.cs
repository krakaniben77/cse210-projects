using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by guiding slow breathing. Clear your mind and focus on your breath.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(duration);
        
        while (DateTime.Now < end)
        {
            Console.Write("Breath in..");
            Countdown(4);

            Console.Write("Breath out..");
            Countdown(6);

            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}
    