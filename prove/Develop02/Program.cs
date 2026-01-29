using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Prompts prompts = new Prompts();
        Journal journal = new Journal();

        string user_input = "";
        Console.WriteLine("Welcome to the journal project!");
        while (user_input != "5")
        {
            Console.WriteLine("Please choose one of the following:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            user_input = Console.ReadLine();

            if (user_input == "1")
            {
                // Allow the user to create a new journal entry
                string journal_prompt = prompts.GetRandomPrompt();
                Console.WriteLine(journal_prompt); // Display the journal prompt for the user
                Console.Write("> ");

                string journal_input = Console.ReadLine();

                Entry journal_entry = new Entry(journal_prompt, journal_input);

                // Add the journal entry to the Journal class
                journal.AddEntry(journal_entry);
            }
            else if (user_input == "2")
            {
                // Display all journal entries
                journal.DisplayEntries();
            }
            else if (user_input == "3")
            {
                // Load ze text file that contains journal entries
                Console.WriteLine("What is the file name?");
                Console.Write("> ");

                string filename = Console.ReadLine();

                // Instruct the journal class to load entries from select file
                journal.LoadEntries(filename);
            }
            else if (user_input == "4")
            {
                // Overwrite the text file that contains the journal entries
                Console.WriteLine("What should the file name be?");
                Console.Write("> ");

                string filename = Console.ReadLine();

                // Instruct the journal class to save entries from select file
                journal.SaveEntries(filename);
            }

            // Console.WriteLine(); // Add a blank line for stylization and spacing
        }
        Console.WriteLine("Goodbye!");
    }
}