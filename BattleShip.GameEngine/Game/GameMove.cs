using BattleShip.GameEngine.Area;

namespace BattleShip.GameEngine.Game;

public class GameMove
{
    public GameMove(Guid playerId, Guid nextPlayerId, Point point, bool attackHitTarget)
    {
        PlayerId = playerId;
        NextPlayerId = nextPlayerId;
        Point = point;
        AttackHitTarget = attackHitTarget;
        ExecutionTime = DateTime.Now;
    }
    
    public Guid PlayerId { get; }
    public Guid NextPlayerId { get; }
    public Point Point { get; }
    public bool AttackHitTarget { get; }
    public DateTime ExecutionTime { get; }
}