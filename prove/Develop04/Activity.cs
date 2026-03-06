abstract class Activity
{
    private string _name;
    private string _introduction;
    private int _activityDuration;

    public Activity(string name, string introduction)
    {
        _name = name; // Name of the activity
        _introduction = introduction; // Introduction on what will happen during the activity.
    }

    public int ActivityDuration() { return _activityDuration; }

    public virtual void DisplayIntroduction()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name} Activity!");
        Console.WriteLine(); // Spacer
        Console.WriteLine(_introduction);
        Console.WriteLine(); // Spacer
        Console.Write($"For how many seconds would you like to participate in this activity? ");

        int input;
        // AI generated this nifty while statement for a different projects, so I decided to steal it here
        while (!int.TryParse(Console.ReadLine(), out input) || input <= 0)
        {
            Console.Write("Please enter a positive number of seconds: ");
        }
        _activityDuration = input;
    }
    
    public abstract void DisplayActivity();

    public virtual void DisplayConclusion()
    {
        Console.WriteLine();
        Console.WriteLine($"Congratulations! You have concluded your {_name.ToLower()} session.");
        Console.WriteLine("The activity will now close in 5 seconds.");
        Wait.WaitingUI(5);
    }
}