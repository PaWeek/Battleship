using BattleShip.GameEngine.Area;

namespace BattleShip.GameEngine.Ships;

public class Destroyer : Ship
{
    private const string ShipName = nameof(Destroyer);
    private const short ShipSize = 3;
    
    public Destroyer() :
        base(ShipName, ShipSize) {}
    
    public Destroyer(Point start, Directions direction) : 
        base(ShipName, ShipSize, start, direction) {}
}