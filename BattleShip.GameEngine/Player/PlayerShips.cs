using BattleShip.GameEngine.Area;
using BattleShip.GameEngine.Ships;

namespace BattleShip.GameEngine.Plaxyer;

public class PlayerShips
{
    public PlayerShips(
        Carrier carrier, 
        Battleship battleShip, 
        Destroyer destroyer, 
        Submarine submarine, 
        PatrolBoat patrolBoat)
    {
        Carrier = carrier;
        BattleShip = battleShip;
        Destroyer = destroyer;
        Submarine = submarine;
        PatrolBoat = patrolBoat;
    }

    public Carrier Carrier { get; }
    public Battleship BattleShip { get; }
    public Destroyer Destroyer { get; }
    public Submarine Submarine { get; }
    public PatrolBoat PatrolBoat { get; }

    public IEnumerable<Point> GetAllShipsLocations() 
        => GetShipsLocation(Carrier, BattleShip, Destroyer, Submarine, PatrolBoat);

    private static IEnumerable<Point> GetShipsLocation(params Ship[] ships) 
        => ships.SelectMany(x => x.Location?.Points).ToList();
}