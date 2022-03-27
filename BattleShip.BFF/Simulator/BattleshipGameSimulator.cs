using BattleShip.GameEngine.Area;
using BattleShip.GameEngine.Game;
using BattleShip.GameEngine.GameBuilder;
using BattleShip.GameEngine.Plaxyer;
using BattleShip.GameEngine.Ships;

namespace BattleShip.BFF.Simulator;

public class BattleshipGameSimulator : IBattleshipGameSimulator
{
    private readonly IBattleshipGameBuilder _gameBuilder;
    private readonly AreaSize _areaSize;

    public BattleshipGameSimulator(IBattleshipGameBuilder gameBuilder)
    {
        _gameBuilder = gameBuilder;
        _areaSize = new AreaSize(10, 10);
    }
    
    public BattleshipGame SimulateGame(string player1Name, string player2Name)
    {
        SetShipsOnArea();
        var game = StartGame(player1Name, player2Name);
        SimulateAllMoves(game);

        return game;
    }

    private void SimulateAllMoves(BattleshipGame game)
    {
        var random = new Random();
        while (game.Winner is null)
        {
            var target = new Point(random.Next(1, _areaSize.X + 1), random.Next(1, _areaSize.Y + 1));

            var playerAreaPoints = game.GetNextPlayerAreaPoints();
            if (playerAreaPoints.Any(x => x.Point.Equals(target) && x.AlreadyAttacked))
                continue;

            game.MakeMove(target);
        }
    }

    private BattleshipGame StartGame(string player1Name, string player2Name)
    {
        return _gameBuilder
            .AddFirstPlayer(player1Name)
            .AddSecondPlayer(player2Name)
            .SetAreaSize(_areaSize.X, _areaSize.Y)
            .Build();
    }
    
    private void SetShipsOnArea()
    {
        var player1Ships = SetPlayerShipsOnArea();
        var player2Ships = SetPlayerShipsOnArea();

        _gameBuilder
            .SetCarriers(player1Ships.Carrier, player2Ships.Carrier)
            .SetBattleships(player1Ships.BattleShip, player2Ships.BattleShip)
            .SetDestroyers(player1Ships.Destroyer, player2Ships.Destroyer)
            .SetSubmarines(player1Ships.Submarine, player2Ships.Submarine)
            .SetPatrolBoats(player1Ships.PatrolBoat, player2Ships.PatrolBoat);
    }
    
    private PlayerShips SetPlayerShipsOnArea()
    {
        var carrier = new Carrier();
        var battleship = new Battleship();
        var destroyer = new Destroyer();
        var submarine = new Submarine();
        var patrolBoat = new PatrolBoat();
        SetupShips(carrier, battleship, destroyer, submarine, patrolBoat);
        return new PlayerShips(carrier, battleship, destroyer, submarine, patrolBoat);
    }

    private void SetupShips(params Ship[] ships)
    {
        var assignedPoints = new List<Point>();
        
        foreach (var ship in ships)
        {
            ship.Location = GenerateLocation(ship, assignedPoints);
            assignedPoints.AddRange(ship.Location.Points);
        }
    }


    private ShipLocation GenerateLocation(Ship ship, ICollection<Point> assignedPoints)
    {
        while (true)
        {
            var random = new Random();
            var directions = Enum.GetValues(typeof(Directions));
            var randomDirection = (Directions) (directions.GetValue(random.Next(directions.Length)) ?? Directions.Horizontal);

            int randomX;
            int randomY;

            if (randomDirection == Directions.Horizontal)
            {
                randomX = random.Next(1, _areaSize.X + 1 - ship.Size);
                randomY = random.Next(1, _areaSize.Y);
            }
            else
            {
                randomX = random.Next(1, _areaSize.X);
                randomY = random.Next(1, _areaSize.Y + 1 - ship.Size);
            }

            var shipLocation = new ShipLocation(ship.Size, new Point(randomX, randomY), randomDirection);
            if (assignedPoints.Any(x => shipLocation.Points.Contains(x))) continue;

            return shipLocation;
        }
    }
}