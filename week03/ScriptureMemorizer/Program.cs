using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        Console.Clear();
        Console.WriteLine("Scripture Memorizer Program");
        Console.WriteLine("-----------------------");

        Reference reference = new Reference("John", 3, "16");

        string verse= "For God so loved the world that he gave his only begotten son "
                      + "that whosoever believe in him should not perish but have everlasting life.";

        ScriptureMemorizer   scriptureMemorizer = new ScriptureMemorizer(reference, verse);

        string input = "";
        while (input != "quit" && !scriptureMemorizer.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scriptureMemorizer.GetDisplayText());
            Console.WriteLine("Press Enter to hide words or typy 'quit'to exit.");
            input= Console.ReadLine();

            if (input != "quit")
            {
                scriptureMemorizer.HideRandomWords(3);
            }
        }
        Console.Clear();
        Console.WriteLine("Goodbye👋");
    }
}