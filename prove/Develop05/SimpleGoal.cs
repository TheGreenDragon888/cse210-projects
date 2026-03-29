class SimpleGoal : Goal
{
    // Creates an empty goal class to be initialized with the CreateGoal function
    public SimpleGoal() : base() { }

    // Initializes the goal using information loaded from file
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }
}