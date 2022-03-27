using BattleShip.GameEngine.Area;
using BattleShip.GameEngine.Plaxyer;

namespace BattleShip.GameEngine.Player;

public class Player
{
    public Player(string name, PlayerShips ships)
    {
        Id = Guid.NewGuid();
        Name = name;
        Ships = ships;
    }

    public Guid Id { get; }
    public string Name { get; }
    public PlayerShips Ships { get; }

    public IEnumerable<Point> GetPlayerShipsPosition() 
        => Ships.GetAllShipsLocations();

    //public override bool Equals(object? obj) 
    //    => ((Player) obj!).Id == Id;
}