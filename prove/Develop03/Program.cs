using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture genesis_intro = new Scripture("Genesis 1:1-4", new List<string> {
            "In the beginning God created the heaven and the earth.",
            "And the earth was without form, and void; and darkness was upon the face of the deep. And the Spirit of God moved upon the face of the waters.",
            "And God said, Let there be light: and there was light.",
            "And God saw the light, that it was good: and God divided the light from the darkness."
        }, 1);

        float hide_word_percentage = 0;

        string user_input = "";
        while (user_input.ToLower() != "quit") // Exit if 'quit' is typed
        {
            genesis_intro.SetWordPercentage(hide_word_percentage);

            // Console.Clear();
            genesis_intro.DisplayScripture();
            Console.WriteLine("Press enter to continue, 'back' to go back, and 'quit' to finish.");
            
            user_input = Console.ReadLine(); // Yeilds and waits for user input

            if (user_input.ToLower() == "back")
            {
                hide_word_percentage -= 0.1f; // Hides 10% more words
                if (hide_word_percentage < 0) // Below 0 bring to 0
                    { hide_word_percentage = 0; }
            }
            else
            {
                hide_word_percentage += 0.1f; // Hides 10% more words
                if (hide_word_percentage > 1) // Below 1 bring to 1
                    { hide_word_percentage = 1; }
            }
        }
    }
}