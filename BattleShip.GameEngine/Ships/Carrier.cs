using BattleShip.GameEngine.Area;

namespace BattleShip.GameEngine.Ships;

public class Carrier : Ship
{
    private const string ShipName = nameof(Carrier);
    private const short ShipSize = 5;
    
    public Carrier() :
        base(ShipName, ShipSize) {}
    
    public Carrier(Point start, Directions direction) : 
        base(ShipName, ShipSize, start, direction) {}
}