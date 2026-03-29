class ChecklistGoal : Goal
{
    public int TimesToComplete;
    public int TimesCompleted;

    // Creates an empty goal class to be initialized with the CreateGoal function
    public ChecklistGoal() : base()
    {
        TimesToComplete = 0;
        TimesCompleted = 0;
    }

    // Initializes the goal using information loaded from file
    public ChecklistGoal(string name, string description, int points, int timesToComplete, int timesCompleted = 0)
        : base(name, description, points)
    {
        TimesToComplete = timesToComplete;
        TimesCompleted = timesCompleted;
        IsComplete = timesCompleted >= timesToComplete;
    }

    public override void CreateGoal()
    {
        base.AskGoalFundamentals(); // Use the base class's "AskGoalFundamentals"

        // Then we ask the remaining questions for the checklist goal
        Console.Write("How many times does this goal need to be completed? ");
        int.TryParse(Console.ReadLine(), out int times);
        TimesToComplete = times;
    }

    public override void Complete()
    {
        // Limited completion times
        if (TimesToComplete <= 0) return;

        TimesCompleted++; 
        if (TimesCompleted >= TimesToComplete)
            IsComplete = true;
    }

    public override string GetStringRepresentation()
    {
        return $"[{(IsComplete ? "X" : " ")}] {Name} ({Description}) -- Currently completed: {TimesCompleted}/{TimesToComplete} ({Points} points)";
    }

    public override string SerializeData()
    {
        return $"{Name}|{Description}|{Points}|{IsComplete}|{TimesCompleted}|{TimesToComplete}";
    }
}