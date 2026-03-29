class Goal
{
    public string Name;
    public string Description;
    public int Points;
    public bool IsComplete;

    public Goal()
    {
        Name = string.Empty;
        Description = string.Empty;
        Points = 0;
        IsComplete = false;
    }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsComplete = false;
    }

    public virtual void MarkComplete() => IsComplete = true;

    public virtual void Complete()
    {
        if (!IsComplete)
            MarkComplete();
    }

    public virtual int GetPoints() => Points;

    public virtual string GetStringRepresentation()
    {
        return $"[{(IsComplete ? "X" : " ")}] {Name} ({Description}) {Points} points";
    }

    public virtual void CreateGoal() => AskGoalFundamentals();

    public virtual void AskGoalFundamentals()
    {
        // Template for goal creation
        Console.Write("What is the name of your goal? ");
        Name = Console.ReadLine() ?? string.Empty;

        Console.Write("Describe your goal: ");
        Description = Console.ReadLine() ?? string.Empty;

        Console.Write("How many points should your goal be worth? ");
        int.TryParse(Console.ReadLine(), out int parsedPoints);
        Points = parsedPoints;
    }

    public virtual string SerializeData()
    {
        // Type|Name|Description|Points|IsComplete|TimesCompleted|TimesToComplete
        return $"{Name}|{Description}|{Points}|{IsComplete}|0|0";
    }
}