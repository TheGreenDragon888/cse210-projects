using System.Runtime.InteropServices;

class Verse
{
    private ushort _verse_number; // Supports verse counting from 0 to 65,535
    private List<Word> _content;

    public Verse(string verse_content, ushort verse_number)
    {
        _verse_number = verse_number;
        _content = new List<Word>(); // Instantiates a new empty list

        // Seperate the text into seperate words in an array
        string[] word_list = verse_content.Split(" ");
        foreach (string word in word_list)
        {
            Word new_word = new Word(word); //Creates new word word
            _content.Add(new_word); // Adds word word to word word
        }
    }

    public string GetVerse()
    {
        // Displays the verse number and then iterates through the words to display them all
        string verse_to_return = $"{_verse_number}";
        foreach (Word word in _content)
        {
            verse_to_return = $"{verse_to_return} {word.GetText()}";
        }
        return verse_to_return;
    }

    public float EvaluatePercentHiddenWords()
    {
        uint visible_word_count = 0;
        foreach (Word word in _content)
        {
            if (word.IsVisible())
            {
                visible_word_count++;
            }
        }
        return 1 - (float)visible_word_count / (float)_content.Count;
    }

    private bool AreApproximatelyEqual(float a, float b, float tolerance = 0.001f)
    {
        return Math.Abs(a - b) < tolerance;
    }

    public void HideWordPercentage(float percentage)
    {
        percentage = Math.Clamp(percentage, 0.0f, 1.0f); // Automatically normalize to min 0 or max 1

        // Force all words to be visible first
        foreach (Word word in _content)
            { word.SetVisibility(true); }

        Random random = new Random(83460); // Seed 83460 which is the BYUI zip code

        float evaluated_hidden_percentage = 0f;
        while (evaluated_hidden_percentage < percentage)
        {
            // Hide words until hidden word percentage is greater than desired percentage
            _content[random.Next(_content.Count)].SetVisibility(false); // Hide a random word
            evaluated_hidden_percentage = EvaluatePercentHiddenWords();

            // Console.WriteLine($"eval: {evaluated_hidden_percentage}, %: {percentage}");
        }
    }
}