class ChecklistGoal : Goal
{
    public int TimesToComplete { get; set; }
    public int TimesCompleted { get; set; }

    public ChecklistGoal() : base()
    {
        TimesToComplete = 0;
        TimesCompleted = 0;
    }

    public ChecklistGoal(string name, string description, int points, int timesToComplete, int timesCompleted = 0)
        : base(name, description, points)
    {
        TimesToComplete = timesToComplete;
        TimesCompleted = timesCompleted;
        IsComplete = timesCompleted >= timesToComplete;
    }

    public override void CreateGoal()
    {
        base.CreateGoal();
        Console.Write("How many times does this goal need to be completed? ");
        int.TryParse(Console.ReadLine(), out int times);
        TimesToComplete = times;
    }

    public override void Complete()
    {
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