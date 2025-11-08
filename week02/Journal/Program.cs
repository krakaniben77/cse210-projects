using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        Random random = new Random();

        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"

        };

        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1.Write a new entry");
            Console.WriteLine("2.Display the journal");
            Console.WriteLine("3.Save the journal to a file");
            Console.WriteLine("4.Load the journal from a file");
            Console.Write("5.Quit");
            Console.Write("Select option (1-5): ");

            Console.WriteLine();

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid Input. Please try again.");
                continue;
            }
            switch (choice)
            {
                case 1:

                    DateTime theCurrentTime = DateTime.Now;
                    string dateText = theCurrentTime.ToShortDateString();

                    string prompt = prompts[random.Next(prompts.Count)];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write(">>> ");
                    string response = Console.ReadLine();
                    
                    Entry newEntry = new Entry(dateText, prompt, response);
                    journal.AddEntry(newEntry);
                    break;

                case 2:
                    Console.WriteLine("Your Journal Entries:");
                    journal.DisplayAll();
                    break;

                case 3:
                    Console.Write("Enter filname to save (eg. myJournal.txt): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case 4: 
                    Console.Write("Enter filename to load (eg. myJournal.txt): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case 5:
                    Console.WriteLine("Goodbye.");
                    break;

                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;






            }
        }
    }
}