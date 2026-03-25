using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the point system
        Points points = new Points();
        
        // Initialize the goal storage system
        Goals goals = new Goals();

        // Obtain user input
        string userInput = "";
        while (userInput != "4")
        {
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
                    break;
                case "3":
                    // Display the goals with numbers so the user can select which one they completed
                    if (goals.goalList.Count == 0)
                    {
                        Console.WriteLine("No goals to record.");
                        break;
                    }

                    for (int j = 0; j < goals.goalList.Count; j++)
                    {
                        Console.WriteLine($"{j}. {goals.goalList[j].GetStringRepresentation()}");
                    }

                    Console.Write("Enter the number of the goal you completed: ");
                    if (int.TryParse(Console.ReadLine(), out int selectedGoal) && selectedGoal >= 0 && selectedGoal < goals.goalList.Count)
                    {
                        goals.goalList[selectedGoal].Complete();
                        points.IncreaseAndSave(goals.goalList[selectedGoal].GetPoints());
                        Console.WriteLine($"Points: {points.current} (Total: {points.total}, Highscore: {points.highscore})");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                    break;
            }
        }
    }
}