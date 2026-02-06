class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public void SetTop(int new_top)
    {
        _top = new_top;
    }
    public void SetBottom(int new_bottom)
    {
        if (new_bottom != 0)
        {
            _bottom = new_bottom;
        }
        else
        {
            // In the sample solution there is divide by 0 protection
            _bottom = 1;
        }
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}