class Scripture
{
    private string _reference; // The scripture reference
    private List<Verse> _verses; // Tracks verse number and verse text content

    public Scripture(string reference, List<string> verses, ushort startingVerseNumber)
    {
        _reference = reference;
        _verses = new List<Verse>();

        ushort verseCounter = startingVerseNumber;
        foreach (string verse in verses)
        {
            _verses.Add(new Verse(verse, verseCounter)); // Adds a verse with number starting at the start
            verseCounter++;
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