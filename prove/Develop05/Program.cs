using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

/*
To demonstrate extra effort / creativity I have done two things:

1. Your data (point total and goals) automatically save upon the
creation of a goal and incrementation of points.

2. You have three saved point values: your current point value,
your running total point value, and your highscore / highest
current point value achieved.

Each of these are differentiated because your points atrophy over
time. The current POINT_LOSS_PER_DAY is dictated in the Points.cs
file with a value of 50 per day.

Feel free to try it out!
*/

class Program
{
    // The "main menu" loop for the program
    static void Main(string[] args)
    {
        // Initialize the point system
        Points points = new Points();
        
        // Initialize the goal storage system
        Goals goals = new Goals();

        // Main program loop
        string userInput = "";
        while (userInput != "4")
        {
            Console.Clear();
            Console.WriteLine($"Points: {points.current} (Total: {points.total}, Highscore: {points.highscore})");
            Console.WriteLine();
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal");
            Console.WriteLine("4. Quit");

            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Goal newGoal;

                    Console.WriteLine("What type of goal would you like to create? (simple, eternal, checklist)");
                    string goalType = Console.ReadLine().ToLower();

                    switch (goalType)
                    {
                        case "simple":
                            newGoal = new SimpleGoal();
                            break;
                        case "eternal":
                            newGoal = new EternalGoal();
                            break;
                        case "checklist":
                            newGoal = new ChecklistGoal();
                            break;
                        default:
                            Console.WriteLine("Invalid goal type.");
                            Console.ReadLine();
                            continue;
                    }

                    // If the user input an invalid goal type, newGoal will be null
                    if (newGoal != null)
                    {
                        newGoal.CreateGoal();
                        goals.AddGoalAndSave(newGoal);
                    }

                    break;
                case "2":
                    int i = 0;
                    foreach (Goal goal in goals.goalList)
                    {
                        Console.WriteLine($"{i}. {goal.GetStringRepresentation()}");
                        i++;
                    }
                    Console.ReadLine();
                    break;
                case "3":
                    // Display the goals with numbers so the user can select which one they completed
                    if (goals.goalList.Count == 0)
                    {
                        Console.WriteLine("No goals to record.");
                        Console.ReadLine();
                        break;
                    }

                    for (int j = 0; j < goals.goalList.Count; j++)
                    {
                        Console.WriteLine($"{j}. {goals.goalList[j].GetStringRepresentation()}");
                    }

                    Console.Write("Enter the number of the goal you completed: ");
                    if (int.TryParse(Console.ReadLine(), out int selectedGoal) && selectedGoal >= 0 && selectedGoal < goals.goalList.Count && !goals.goalList[selectedGoal].IsComplete)
                    {
                        goals.goalList[selectedGoal].Complete();

                        int pointsEarned = goals.goalList[selectedGoal].GetPoints();

                        points.IncreaseAndSave(pointsEarned);
                        Console.WriteLine($"You have earned {pointsEarned} points! Your current total is now {points.current} points.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                    Console.ReadLine();
                    break;
            }
        }
    }
}