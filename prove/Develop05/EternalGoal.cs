class EternalGoal : Goal
{
    // Creates an empty goal class to be initialized with the CreateGoal function
    public EternalGoal() : base() { }

    // Initializes the goal using information loaded from file
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void Complete()
    {
        // Eternal goals never become "complete" but can be recorded repeatedly.
        // Do not set IsComplete so they remain countable.
    }

    public override int GetPoints() => Points;

    public override string GetStringRepresentation()
    {
        return $"[ ] {Name} ({Description}) {Points} points (Eternal)";
    }

    public override string SerializeData() => $"{Name}|{Description}|{Points}|false|0|0";
}