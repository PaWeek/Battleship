using BattleShip.GameEngine.Area;

namespace BattleShip.GameEngine.Ships;

public class ShipLocation
{
    public ShipLocation(short size, Point start, Directions direction)
    {
        Points = GetAllPoints(start, direction, size);
    }

    public ICollection<Point> Points { get; }

    private static ICollection<Point> GetAllPoints(Point start, Directions direction, short size)
    {
        var points = new List<Point>();
        
        if (direction == Directions.Horizontal)
        {
            for (var i = start.X; i < start.X + size; i++)
            {
                points.Add(new Point(i, start.Y));
            }

            return points;
        }
        
        for (var i = start.Y; i < start.Y + size; i++)
        {
            points.Add(new Point(start.X, i));
        }

        return points;
    }
}