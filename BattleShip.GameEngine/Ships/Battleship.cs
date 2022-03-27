using BattleShip.GameEngine.Area;

namespace BattleShip.GameEngine.Ships;

public class Battleship : Ship
{
    private const string ShipName = nameof(Battleship);
    private const short ShipSize = 4;
    
    public Battleship() :
        base(ShipName, ShipSize) {}
    
    public Battleship(Point start, Directions direction) : 
        base(ShipName, ShipSize, start, direction) {}
}