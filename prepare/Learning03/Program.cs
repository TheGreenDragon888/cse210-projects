using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();
        Random random = new Random();
        
        for (int i = 0; i < 20; i++)
        {
            // The assignment did not specify a range so obviously I'm gonna use the entire integer limit
            fraction.SetTop(random.Next());
            fraction.SetBottom(random.Next());

            Console.WriteLine($"Fraction {i}: string: {fraction.GetFractionString()} Number: {fraction.GetDecimalValue()}");
        }
    }
}