using BattleShip.GameEngine.Area;

namespace BattleShip.GameEngine.Ships;

public class Submarine : Ship
{
    private const string ShipName = nameof(Submarine);
    private const short ShipSize = 3;
    
    public Submarine() :
        base(ShipName, ShipSize) {}
    
    public Submarine(Point start, Directions direction) : 
        base(ShipName, ShipSize, start, direction) {}
}