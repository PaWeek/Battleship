using BattleShip.GameEngine.Area;

namespace BattleShip.GameEngine.Game;

public class BattleshipGame
{
    private readonly Stack<GameMove> _playersMoves;
    
    public BattleshipGame(AreaSize areaSize, Player.Player player1, Player.Player player2)
    {
        Id = Guid.NewGuid();
        AreaSize = areaSize;
        _playersMoves = new Stack<GameMove>();

        if (!CheckPlayersShipsAreOnGameArea(player1, player2))
            throw new Exception();
        
        Player1 = player1;
        Player2 = player2;
    }

    public Guid Id { get; }
    public AreaSize AreaSize { get; }

    public Player.Player Player1 { get; }
    
    public Player.Player Player2 { get; }
    
    public Guid? Winner { get; private set; }

    public IEnumerable<GameMove> GameMoves 
        => _playersMoves.OrderByDescending(x => x.ExecutionTime);

    public GameMove MakeMove(Point target)
    {
        if (Winner != null)
            throw new Exception(); // here should be more specialised exception
        
        if (!IsTargetPointInBattleArea(target))
            throw new Exception(); // here should be more specialised exception

        var playerId = Player1.Id;

        var lastMove = GetLastMove();
        if (lastMove != null)
            playerId = lastMove.NextPlayerId;

        var attackedPoints = GetAttackedArea(playerId);

        if (WasTargetPointAlreadyAttacked(attackedPoints, target))
            throw new Exception(); // here should be more specialised exception
        
        var isAttackHitTheShip = IsAttackHitTheShip(target, playerId == Player1.Id ? Player2 : Player1);
        var nextPlayer = GetNextPlayerMove(isAttackHitTheShip, playerId);
        var move = new GameMove(playerId, nextPlayer, target, isAttackHitTheShip);
        _playersMoves.Push(move);
        Winner = GetWinner();
        return move;
    }

    public IEnumerable<AreaPoint> GetNextPlayerAreaPoints()
    {
        var lastMove = GetLastMove();

        return GetPlayerAreaPoints(lastMove != null ? GetNextPlayerMove(lastMove.AttackHitTarget, lastMove.PlayerId) : Player1.Id);
    }

    private GameMove? GetLastMove()
    {
        _playersMoves.TryPeek(out var lastMove);
        return lastMove;
    }

    private bool IsTargetPointInBattleArea(Point point)
        => point.X <= AreaSize.X && point.X > 0 && 
           point.Y <= AreaSize.Y && point.Y > 0;
    
    private static bool WasTargetPointAlreadyAttacked(ICollection<Point> attackedPoints, Point target) 
        => attackedPoints.Contains(target);

    private static bool IsAttackHitTheShip(Point target, Player.Player attackedPlayer) 
        => attackedPlayer.GetPlayerShipsPosition().Contains(target);

    private ICollection<Point> GetAttackedArea(Guid playerId)
        => _playersMoves
            .Where(x => x.PlayerId == playerId)
            .Select(x => x.Point)
            .ToList();

    private Guid GetNextPlayerMove(bool attackHitTarget, Guid lastPlayerId)
    {
        return attackHitTarget ? 
            lastPlayerId : 
            lastPlayerId == Player1.Id ? 
                Player2.Id : 
                Player1.Id;
    }

    private bool CheckPlayersShipsAreOnGameArea(params Player.Player[] players) 
        => players.SelectMany(x => x.GetPlayerShipsPosition()).All(IsTargetPointInBattleArea);

    private IEnumerable<AreaPoint> GetPlayerAreaPoints(Guid playerId)
    {
        var points = new List<AreaPoint>();
        var attackedPoints = _playersMoves
            .Where(x => x.PlayerId == playerId)
            .ToList();
        
        for (var x = 1; x <= AreaSize.X; x++)
        {
            for (var y = 1; y <= AreaSize.Y; y++)
            {
                var point = new Point(x, y);
                var wasAlreadyAttacked = attackedPoints.Any(move => Equals(move.Point, point));
                points.Add(new AreaPoint(point, wasAlreadyAttacked));
            }
        }

        return points;
    }

    private Guid? GetWinner()
    {
        var player1AttackedArea = GetAttackedArea(Player2.Id);
        var allPlayer1ShipsSunk = Player1.GetPlayerShipsPosition().All(x => player1AttackedArea.Any(x.Equals));
        
        if (allPlayer1ShipsSunk)
            return Player2.Id;

        var player2AttackedArea = GetAttackedArea(Player1.Id);
        var allPlayer2ShipsSunk = Player2.GetPlayerShipsPosition().All(x => player2AttackedArea.Any(x.Equals));

        if (allPlayer2ShipsSunk)
            return Player1.Id;

        return null;
    }
}