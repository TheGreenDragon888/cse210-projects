using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>([
            new Square("Green", 2),
            new Rectangle("Blue", 3, 4),
            new Circle("Red", 3)
        ]);
        
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetName()} is {shape.GetColor()} and has an area of {shape.GetArea():F3}.");
        }
    }
}