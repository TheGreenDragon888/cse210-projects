using System;
using System.IO;
using System.Collections.Generic;

class Goals
{
    private string _goalsDirectory = "GoalsData";

    public List<Goal> goalList;

    public Goals()
    {
        goalList = new List<Goal>();

        if (!Directory.Exists(_goalsDirectory))
        {
            Directory.CreateDirectory(_goalsDirectory);
        }

        LoadGoalsFromFile();
    }

    public void AddGoalAndSave(Goal newGoal)
    {
        goalList.Add(newGoal);
        SaveGoalsToFile();
    }

    private void SaveGoalsToFile()
    {
        string filePath = Path.Combine(_goalsDirectory, "goals.txt");

        using var writer = new StreamWriter(filePath);
        foreach (var goal in goalList)
        {
            writer.WriteLine(SerializeGoal(goal));
        }
    }

    private void LoadGoalsFromFile()
    {
        string filePath = Path.Combine(_goalsDirectory, "goals.txt");

        if (!File.Exists(filePath))
            return;

        using var reader = new StreamReader(filePath);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var goal = DeserializeGoal(line);
            if (goal != null)
                goalList.Add(goal);
        }
    }

    private string SerializeGoal(Goal goal)
    {
        return goal.GetType().Name + "|" + goal.SerializeData();
    }

    private Goal DeserializeGoal(string line)
    {
        var parts = line.Split('|');
        if (parts.Length < 6)
            return null;

        string type = parts[0];
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isComplete = bool.Parse(parts[4]);
        int timesCompleted = int.Parse(parts[5]);
        int timesToComplete = parts.Length >= 7 ? int.Parse(parts[6]) : 0;

        Goal goal = type switch
        {
            nameof(SimpleGoal) => new SimpleGoal(name, description, points),
            nameof(EternalGoal) => new EternalGoal(name, description, points),
            nameof(ChecklistGoal) => new ChecklistGoal(name, description, points, timesToComplete, timesCompleted),
            _ => null
        };

        if (goal != null)
        {
            if (isComplete && !(goal is EternalGoal))
                goal.MarkComplete();
        }

        return goal;
    }
}