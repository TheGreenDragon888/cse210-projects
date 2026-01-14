using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite integer? ");
        return int.Parse(Console.ReadLine());
    }

    static void PromptUserBirthYear(out int input_year)
    {
        Console.Write("What year were you born? ");
        input_year = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int input_int)
    {
        return input_int * input_int;
    }

    static void DisplayResult(string username, int squared_number, int birthyear)
    {
        Console.WriteLine($"{username}, the square of your number is {squared_number}.");
        Console.WriteLine($"{username}, you will turn {2026 - birthyear} this year.");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        string username = PromptUserName();
        int favorite_number = PromptUserNumber();
        int birthyear;
        PromptUserBirthYear(out birthyear);

        DisplayResult(username, SquareNumber(favorite_number), birthyear);
    }
}