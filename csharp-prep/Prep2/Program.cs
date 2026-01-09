using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string grade_response = Console.ReadLine();
        int grade_percentage = int.Parse(grade_response);

        string grade_letter = "F";
        if (grade_percentage >= 90) { grade_letter = "A"; }
        else if (grade_percentage >= 80) { grade_letter = "B"; }
        else if (grade_percentage >= 70) { grade_letter = "C"; }
        else if (grade_percentage >= 60) { grade_letter = "D"; }

        Console.Write($"Your grade is {grade_letter}.");
        if (grade_percentage >= 70)
        {
            Console.Write("\nCongratulations on passing the class!");
        }
        else
        {
            Console.Write("\nYou did not pass the class. Better luck next time!");
        }
    }
}