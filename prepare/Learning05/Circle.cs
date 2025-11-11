using System.IO.Pipes;

public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius)
    {
        _radius = radius;
        SetColor(color);
    }
    
    public override double GetArea()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}