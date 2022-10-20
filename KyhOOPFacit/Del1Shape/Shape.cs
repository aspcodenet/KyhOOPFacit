namespace KyhOOPFacit.Del1Shape;


public class Point
{
    private readonly int _x;
    private readonly int _y;

    public Point(int x, int y)
    {
        _x = x;
        _y = y;
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

