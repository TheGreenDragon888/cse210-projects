class BreathingActivity: Activity
{
    public BreathingActivity() : base("Breathing", "In this activity, you will focus on your breathing.") {}

    public override void DisplayActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Please pace your breathing so you've fully breathed in or out by the time the bar has completed.");
        Wait.WaitingUI(5);
        Console.WriteLine();

        int _activityDuration = ActivityDuration();

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _activityDuration)
        {
            Console.WriteLine("Breathe in through your nose.");
            Wait.WaitingUI(5);
            Console.WriteLine("Breathe out through your mouth.");
            Wait.WaitingUI(10);
        }
    }
}