#nullable enable

class Word
{
    private string _text;
    private bool _visible;

    public Word(string text, bool? visible = null)
    {
        _text = text;
        _visible = visible ?? true; // Defaults to true if no value (null) is provided
    }

    public bool IsVisible()
        { return _visible; }

    public void SetVisibility(bool visibility)
        { _visible = visibility; }

    private char[] punctuation = { '.', ',', '!', '?', ';', ':' };
    public string GetText()
    {
        if (_visible)
        {
            return _text;
        }
        else
        {
            string censoredText = "";
            foreach (char letter in _text.ToCharArray())
            {
                if (punctuation.Contains(letter)) // Contains punctuation? Keep it shown!
                {
                    censoredText = $"{censoredText}{letter}";
                }
                else
                {  
                    censoredText = $"{censoredText}_";
                }

            } // Creates underscores for each letter in word
            return censoredText;
        }
    }
}