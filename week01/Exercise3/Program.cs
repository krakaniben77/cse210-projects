using System;

class Program
{
    static void Main(string[] args)
    {
        
        // Console.WriteLine("Hello World! This is the Exercise3 Project.");
        // Console.Write("What is the magic number? ");
        // string magicNumber = Console.ReadLine();
        // int number= int.Parse(magicNumber);

        
        
        
        string keepPlaying = "yes";

        while (keepPlaying.ToLower() == "yes")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;


            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string yourGuess = Console.ReadLine();
                guess= int.Parse(yourGuess);

                if (guess > magicNumber)
                {
                Console.WriteLine("Higher");
                }
                else if (guess < magicNumber)
                {
                Console.WriteLine("Lower");
                }
                else
                {
                Console.WriteLine("You guessed it!");
                }

            }
            Console.Write("Do you want to play again? Yes/No ");
            keepPlaying = Console.ReadLine();

            
           
        }
        Console.WriteLine("Good bye");

        
    
    }
}