class BreathingActivity: Activity
{
    public BreathingActivity() : base("Breathing", "You're gonna start breathin' today.") {}

    public override void DisplayActivity()
    {
        Console.WriteLine();
        Console.WriteLine("BEGINNING ACTIVITY.");
        Console.WriteLine();

        int _activityDuration = ActivityDuration();

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _activityDuration)
        {
            Console.WriteLine("BREATHE IN THROUGH YOUR NOSE.");
            Wait.WaitingUI(5);
            Console.WriteLine("BREATHE OUT THROUGH YOUR MOUTH.");
            Wait.WaitingUI(10);
        }
    }
}