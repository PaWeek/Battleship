namespace BattleShip.GameEngine.Area;

public class AreaPoint
{
    public AreaPoint(Point point, bool alreadyAttacked)
    {
        Point = point;
        AlreadyAttacked = alreadyAttacked;
    }

    public Point Point { get; }
    public bool AlreadyAttacked { get; set; }
}