#nullable enable

public class Entry
{
    public string _input;
    public string _prompt;
    public string _datetext;

    public Entry(string prompt, string input, string? datetext = null)
    {
        _input = input; // Enters the user input
        _prompt = prompt; // Set the prompt that prompted the user
        if (datetext == null)
        {
            // If no date timestamp is provided, create our own
            DateTime timestamp = DateTime.Now; // Gets the current UTC datetime
            _datetext = timestamp.ToShortDateString();
        }
        else
        {
            // Date timestamp was provided, so write that to this entry
            _datetext = datetext;
        }
    }

    public void DisplayEntry()
    {
        // Write the entry to the console
        Console.WriteLine($"{_datetext} - {_prompt}\n{_input}");
    }
}