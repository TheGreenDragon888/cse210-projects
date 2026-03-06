class Rectangle: Shape
{
    private double _length;
    private double _width;

    public Rectangle(string color, double length, double width)
        : base(color, "Rectangle")
    {
        _width = width;
        _length = length;
    }

    public override double GetArea()
    {
        return _length * _width;
    }
}