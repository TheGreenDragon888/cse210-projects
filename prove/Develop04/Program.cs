using System;

class Program
{
    static void Main(string[] args)
    {
        int activityCount = 0;

        string userInput = "";
        while (userInput != "4")
        {
            Console.Clear(); // Clear the console

            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                BreathingActivity activity = new BreathingActivity();

                activity.DisplayIntroduction();
                activity.DisplayActivity();
                activity.DisplayConclusion();

                activityCount++;
            }
            else if (userInput == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();

                activity.DisplayIntroduction();
                activity.DisplayActivity();
                activity.DisplayConclusion();

                activityCount++;
            }
            else if (userInput == "3")
            {
                ListingActivity activity = new ListingActivity();

                activity.DisplayIntroduction();
                activity.DisplayActivity();
                activity.DisplayConclusion();

                activityCount++;
            }
            
            // Was tryna be silly here 
            // {
            //     Console.WriteLine("Listen bucko. Nobody thinks you're funny just cause you can't type a number.");
            //     System.Threading.Thread.Sleep(600);
            //     Console.WriteLine("okay nevermind I kinda do");
            //     System.Threading.Thread.Sleep(150);
            // }
        }

        Console.WriteLine();
        // Make sure I'm being gramatically correct based on the number of activites
        Console.WriteLine($"You performed {activityCount} activit{(activityCount == 1 ? "y" : "ies")} this session!");
        Wait.WaitingUI(5);

        Console.WriteLine();
        Console.WriteLine("See you later!");
    }
}