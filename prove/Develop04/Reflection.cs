class ReflectionActivity: Activity
{
    public ReflectionActivity() : base("Reflection", "In this activity you will be provided a prompt and then time to reflect on provided questions related to that prompt..") {}

    string[] _prompts = [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ];
    string[] _questions = [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ];

    public override void DisplayActivity()
    {
        Random random = new Random();

        Console.WriteLine();
        Console.WriteLine(_prompts[random.Next(_prompts.Length)]);
        Wait.WaitingUI(10);
        Console.WriteLine();

        int _activityDuration = ActivityDuration();

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _activityDuration)
        {
            Console.WriteLine(_questions[random.Next(_questions.Length)]);
            Wait.WaitingUI(15);
        }
    }
}