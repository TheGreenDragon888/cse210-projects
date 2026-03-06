class Circle: Shape
{
    private double _radius;

    public Circle(string color, double radius)
        : base(color, "Circle")
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}