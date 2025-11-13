using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Fractions Project.");
        Fractions f1= new Fractions();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fractions f2= new Fractions(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fractions f3= new Fractions(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fractions f4= new Fractions(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());
    }
}