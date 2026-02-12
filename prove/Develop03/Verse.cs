using System.Runtime.InteropServices;

class Verse
{
    private ushort _verseNumber; // Supports verse counting from 0 to 65,535
    private List<Word> _content;

    public Verse(string verseContent, ushort verseNumber)
    {
        _verseNumber = verseNumber;
        _content = new List<Word>(); // Instantiates a new empty list

        // Seperate the text into seperate words in an array
        string[] wordList = verseContent.Split(" ");
        foreach (string word in wordList)
        {
            Word newWord = new Word(word); //Creates new word word
            _content.Add(newWord); // Adds word word to word word
        }
    }

    private float EvaluatePercentHiddenWords()
    {
        uint visibleWordCount = 0;
        foreach (Word word in _content)
        {
            if (word.IsVisible())
            {
                visibleWordCount++;
            }
        }
        return 1 - (float)visibleWordCount / (float)_content.Count;
    }

    public void HideWordPercentage(float percentage)
    {
        percentage = Math.Clamp(percentage, 0.0f, 1.0f); // Automatically normalize to min 0 or max 1

        // Force all words to be visible first
        foreach (Word word in _content)
            { word.SetVisibility(true); }

        Random random = new Random(83460); // Seed 83460 which is the BYUI zip code

        float evaluatedHiddenPercentage = 0f;
        while (evaluatedHiddenPercentage < percentage)
        {
            // Hide words until hidden word percentage is greater than desired percentage
            _content[random.Next(_content.Count)].SetVisibility(false); // Hide a random word
            evaluatedHiddenPercentage = EvaluatePercentHiddenWords();

            // Console.WriteLine($"eval: {evaluatedHiddenPercentage}, %: {percentage}");
        }
    }

    public string GetVerse()
    {
        // Displays the verse number and then iterates through the words to display them all
        string verseToReturn = $"{_verseNumber}";
        foreach (Word word in _content)
        {
            verseToReturn = $"{verseToReturn} {word.GetText()}";
        }
        return verseToReturn;
    }
}