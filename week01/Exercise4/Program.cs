using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        // Console.WriteLine("Hello World! This is the Exercise4 Project.");
        // Console.WriteLine(" Enter a list of numbers, type 0 when finished.");

        int enterNumber = -1;
        while (enterNumber != 0)
        {
            Console.Write("Enter number: ");
            string getResponse = Console.ReadLine();
            enterNumber = int.Parse(getResponse);

            numbers.Add(enterNumber);
            
            // if (enterNumber != 0)
            // {
            //     numbers.Add(enterNumber);
            // }
            

        }
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The total is: {sum}");

       
       float average = ((float)sum) /numbers.Count;
       Console.WriteLine($"The average is: {average}");
       int maximum = numbers[0];
       foreach (int number in numbers)
       {
           if (number > maximum)
           {
               maximum = number;
           }

        //    else if (number < min)
        //    {
        //        min = number;
        //    }

       }
       Console.WriteLine($"The maximum number is {maximum}");

    }
}