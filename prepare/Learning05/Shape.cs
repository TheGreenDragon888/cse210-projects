abstract class Shape
{
    private string _name;
    private string _color;

    public Shape(string color, string shapeName)
    {
        _color = color;
        _name = shapeName;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string newColor)
    {
        _color = newColor;
    }

    public abstract double GetArea();
}