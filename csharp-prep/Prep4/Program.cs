using System;
using System.Collections.Generic;
using System.Runtime;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input_number = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (input_number != 0)
        {
            Console.Write("Enter number: ");
            input_number = int.Parse(Console.ReadLine());

            if (input_number != 0)
                numbers.Add(input_number);
        }

        int largest = -999999;
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
            if (num > largest)
                largest = num; // Omit the {} when it's single line
        }
        double avg = (double)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}