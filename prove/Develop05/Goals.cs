using System;
using System.IO;
using System.Collections.Generic;

class Goals
{
    public List<Goal> goalList;

    private string filePath = "Goals.txt";

    public Goals()
    {
        goalList = new List<Goal>();

        LoadGoalsFromFile();
    }

    public void AddGoalAndSave(Goal newGoal)
    {
        goalList.Add(newGoal);
        SaveGoalsToFile();
    }

    // Claude AI assisted me on how to quickly read and write files with Stream Writer & Reader
    private void SaveGoalsToFile()
    {
        StreamWriter writer = new StreamWriter(filePath);
        foreach (Goal goal in goalList)
        {
            writer.WriteLine(SerializeGoal(goal));
        }
    }

    private void LoadGoalsFromFile()
    {
        if (!File.Exists(filePath))
            return;

        StreamReader reader = new StreamReader(filePath);
        string line;
        // Iterate through each line within the save file
        while ((line = reader.ReadLine()) != null)
        {
            Goal goal = DeserializeGoal(line);
            if (goal != null)
                goalList.Add(goal);
        }
    }

    // Claude AI advised me on how to serialize the goal data for the save file
    private string SerializeGoal(Goal goal)
    {
        return goal.GetType().Name + "|" + goal.SerializeData();
    }

    private Goal DeserializeGoal(string line)
    {
        string[] parts = line.Split('|');
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