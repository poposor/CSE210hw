public class Rectangle : Shape
{
    private double _width;
    private double _height;

    public Rectangle(string color, double width, double height)
    {
        _width = width;
        _height = height;
        SetColor(color);
    }
    
    public override double GetArea()
    {
        return _width * _height;
    }
}