class Scripture
{
    private string _reference; // The scripture reference
    private List<Verse> _verses; // Tracks verse number and verse text content

    public Scripture(string reference, List<string> verses, ushort starting_verse_number)
    {
        _reference = reference;
        _verses = new List<Verse>();

        ushort verse_counter = starting_verse_number;
        foreach (string verse in verses)
        {
            _verses.Add(new Verse(verse, verse_counter)); // Adds a verse with number starting at the start
            verse_counter++;
        }
    }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine(_reference); // Display scripture reference
        // Display verses
        foreach (Verse verse in _verses)
        {
            Console.WriteLine(verse.GetVerse());
        }
        Console.WriteLine(); // Add a blank line at the end
    }

    public void SetWordPercentage(float percentage)
    {
        // Sets the hide word percentage for each verse object
        foreach (Verse verse in _verses)
        {
            verse.HideWordPercentage(percentage);
        }
    }
}