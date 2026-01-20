public abstract class Shape

{   //properties
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    //constructor
    public Shape(int id, string name, string color)
    {
        Id = id;
        Name = name;
        Color = color;
    }
    public abstract double CalculateArea();
}

public class Circle : Shape
{
    public double Radius { get; set; }
    public Circle(int id, string name, string color, double radius) : base(id, name, color)
    {
        Radius = radius;
    }
    public override double CalculateArea()
    {
        return System.Math.PI * Radius * Radius;
    }
}

public class Square : Shape
{
    public double SideLength {get; set;}
    public Square(int id, string name, string color, double sideLength) : base(id, name, color)
    {
        SideLength = sideLength;
    }
    public override double CalculateArea()
    {
        return SideLength * SideLength;
    }
}

