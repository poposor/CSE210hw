using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("red", 3));
        shapes.Add(new Rectangle("green", 6, 7));
        shapes.Add(new Circle("blue", 3.14));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"A {shape.GetColor()} shape has an area of {shape.GetArea()}");
        }
    }
}