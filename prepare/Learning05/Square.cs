class Square: Shape
{
    private double _side;

    public Square(string color, double side)
        : base(color, "Square")
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}