using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("What is your grade percentage? ");
        string percentage =  Console.ReadLine();
        int percent = int.Parse(percentage);

        if (percent >= 90)
        {
            Console.WriteLine("Your grade is: A");
        }
        else if (percent >= 80)
        {
            Console.WriteLine("Your grade is: B");
        }
        else if (percent >= 70)
        {
            Console.WriteLine("Your grade is: C");
        }
         else if (percent >= 60)
        {
            Console.WriteLine("Your grade is: D");
        }
         else 
        {
            Console.WriteLine("Your grade is: F");
        }

        if (percent >= 70)
        {
            Console.WriteLine($"You Passed.");
        }
        else
        {
            Console.WriteLine($"Must sit up!!!");
        } 

    }
}