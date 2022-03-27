using BattleShip.GameEngine.Area;

namespace BattleShip.GameEngine.Ships;

public abstract class Ship
{
    protected Ship(string name, short size)
    {
        Name = name;
        Size = size;
    }
    
    protected Ship(string name, short size, Point start, Directions direction)
    {
        Name = name;
        Size = size;
        Location = new ShipLocation(size, start, direction);
    }

    public string Name { get; }
    public short Size { get; }
    public ShipLocation? Location { get; set; }
}