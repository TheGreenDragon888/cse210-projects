using System.IO;

public class Journal
{
    List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry new_entry)
    {
        // Adds a new entry to the list
        _entries.Add(new_entry);
    }
    public void DisplayEntries()
    {
        // Display all entries currently on the text file
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
            Console.WriteLine(); // Add a blank line for stylization and spacing
        }
    }

    public void SaveEntries(string filename)
    {
        // Saves all entires to the text file
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._prompt},-'{entry._input},-'{entry._datetext}");
            }
        }
    }
    public void LoadEntries(string filename)
    {
        // Loads all entries currently on the text file
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",-'");

            string prompt = parts[0];
            string entry = parts[1];
            string datetext = parts[2];

            // Add new entry to program
            AddEntry(new Entry(prompt, entry, datetext));
        }
    }
}