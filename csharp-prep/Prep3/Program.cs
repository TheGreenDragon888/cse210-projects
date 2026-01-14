using System;

class Program
{
    static void Main(string[] args)
    {
        int highest_number = 100;

        Random randomGenerator = new Random();
        int random_number = randomGenerator.Next(1, highest_number);

        int input_number = -1;
        int guesses_total = 0;

        while (input_number != random_number)
        {
            Console.Write("What is your guess? (1-100) ");
            string input_response = Console.ReadLine();
            input_number = int.Parse(input_response);

            guesses_total++; // Iterate guesses by 1 after making a guess

            if (input_number > random_number)
            {
                Console.WriteLine("Lower");
            }
            else if (input_number < random_number)
            {
                Console.WriteLine("Higher");
            }
        }
        Console.WriteLine($"You guessed it in {guesses_total} guesses!");
    }
}