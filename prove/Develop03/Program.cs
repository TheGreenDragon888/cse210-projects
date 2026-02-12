using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture genesisIntro = new Scripture("Genesis 1:1-4", new List<string> {
            "In the beginning God created the heaven and the earth.",
            "And the earth was without form, and void; and darkness was upon the face of the deep. And the Spirit of God moved upon the face of the waters.",
            "And God said, Let there be light: and there was light.",
            "And God saw the light, that it was good: and God divided the light from the darkness."
        }, 1);

        float hideWordPercentage = 0;

        string userInput = "";
        while (userInput.ToLower() != "quit") // Exit if 'quit' is typed
        {
            genesisIntro.SetWordPercentage(hideWordPercentage);

            // Console.Clear();
            genesisIntro.DisplayScripture();
            Console.WriteLine("Press enter to continue, 'back' to go back, and 'quit' to finish.");
            
            userInput = Console.ReadLine(); // Yeilds and waits for user input

            if (userInput.ToLower() == "back")
            {
                hideWordPercentage -= 0.1f; // Hides 10% more words
                if (hideWordPercentage < 0) // Below 0 bring to 0
                    { hideWordPercentage = 0; }
            }
            else
            {
                hideWordPercentage += 0.1f; // Hides 10% more words
                if (hideWordPercentage > 1) // Below 1 bring to 1
                    { hideWordPercentage = 1; }
            }
        }
    }
}