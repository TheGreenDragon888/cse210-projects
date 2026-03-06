using System.Reflection.Metadata;

class ListingActivity : Activity
{
    public ListingActivity() : base("Listing", "You're gonna start listin' today.") {}

    string[] _prompts = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    ];
    
    public override void DisplayActivity()
    {
        Random random = new Random();

        Console.WriteLine();
        Console.WriteLine(_prompts[random.Next(_prompts.Length)]);
        Wait.WaitingUI(10);
        Console.WriteLine();

        int _activityDuration = ActivityDuration();

        int _itemCount = 0;

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _activityDuration)
        {
            Console.ReadLine();
            _itemCount++;
        }

        Console.WriteLine();
        Console.WriteLine($"You have listed {_itemCount} items!");
        Wait.WaitingUI(5);
    }
}