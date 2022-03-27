namespace BattleShip.GameEngine.Area;

public class Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        var point = (Point) obj;

        return point.X == X && point.Y == Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}