namespace ReactiveRectangle.Core.Models;

public class Rectangle(double height, double width)
{
    private double Height { get; set; } = height;
    private double Width { get; set; } = width;

    public double GetHeight() => Height;
    public double GetWidth() => Width;
    
    public double Perimeter => (Width + Height) * 2;

    public void Resize(double height, double width)
    {
        Height = height;
        Width = width;
    }
}