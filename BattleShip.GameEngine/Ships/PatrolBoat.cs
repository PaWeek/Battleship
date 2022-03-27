using BattleShip.GameEngine.Area;

namespace BattleShip.GameEngine.Ships;

public class PatrolBoat : Ship
{
    private const string ShipName = nameof(PatrolBoat);
    private const short ShipSize = 2;
    
    public PatrolBoat() :
        base(ShipName, ShipSize) {}
    
    public PatrolBoat(Point start, Directions direction) : 
        base(ShipName, ShipSize, start, direction) {}
}