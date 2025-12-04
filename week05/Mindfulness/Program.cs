using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Mindfulness Project.");
        int option = 0;
        while (option != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");

            if (int.TryParse(Console.ReadLine(), out option)==false)
            {
                option= 0;
            }

            Console.Clear();

            switch (option)
            {
                
                case 1:
                    new BreathingActivity().Run();
                    break;

                case 2:
                    new ReflectionActivity().Run();
                    break;

                case 3:
                    new ListingActivity().Run();
                    break;

                case 4:
                    Console.WriteLine("Goodbye");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (option !=4)
            {
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
            
        }
    }
}