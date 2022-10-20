namespace KyhOOPFacit.Del1Shape;


/*
 *Skapa ny en klass Rectangle också
Implementera  Draw(), GetArea()
Skapa upp en Lista med Shapes (några rectancles, några circles)
Loopa igenom alla och anropa Draw()
 *
 */


public class Point
{
    private readonly int _x;
    private readonly int _y;

    public Point(int x, int y)
    {
        _x = x;
        _y = y;
    }
    public int X
    {
        get { return _x; }
    }
    public int Y
    {
        get { return _y; }
    }
}
public class Shape
{
    private readonly Point _position;
    public Point Position
    {
        get { return _position; }
    }
    public virtual void Draw(){}

    public Shape(Point position)
    {
        _position = position;
    }
}


// Team HAR en lista med PLAYER
// Circle ÄR en shape
//Se till att den (i constructorn) också har en float radius
public class Circle : Shape
{

    private readonly float _radius;
    public Circle(float radius, Point point ):base(point)
    {
        _radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"Ritar it en cirkel på {Position.X},{Position.Y} som är {_radius} stor");
    }


    public double GetArea()
    {
        return Math.PI * Math.Pow(_radius,2);
    }

    public double GetCircumference()
    {
        return _radius * 2;
    }

}

public class Rectangle : Shape
{
    private readonly int _width;
    private readonly int _height;

    public Rectangle(int width, int height, Point point ): base(point)
    {
        _width = width;
        _height = height;
    }

    public double GetArea()
    {
        return  _height * _width;
    }
    public override void Draw()
    {
        Console.WriteLine($"Ritar ut en rektangel på {Position.X},{Position.Y} som är {_width} * {_height} stor");
    }
}



