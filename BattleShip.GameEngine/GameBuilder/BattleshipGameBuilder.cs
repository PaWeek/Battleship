using BattleShip.GameEngine.Area;
using BattleShip.GameEngine.Game;
using BattleShip.GameEngine.Plaxyer;
using BattleShip.GameEngine.Player;
using BattleShip.GameEngine.Ships;

namespace BattleShip.GameEngine.GameBuilder;

public class BattleshipGameBuilder : IBattleshipGameBuilder
{
    private string _player1Name;
    private string _player2Name;

    private AreaSize _areaSize;
    
    private Carrier _player1Carrier;
    private Carrier _player2Carrier;
    
    private Battleship _player1Battleship;
    private Battleship _player2Battleship;
    
    private Destroyer _player1Destroyer;
    private Destroyer _player2Destroyer;
    
    private Submarine _player1Submarine;
    private Submarine _player2Submarine;
    
    private PatrolBoat _player1PatrolBoat;
    private PatrolBoat _player2PatrolBoat;

    
    public IBattleshipGameBuilder AddFirstPlayer(string name)
    {
        _player1Name = name ?? throw new ArgumentNullException(nameof(name));
        return this;
    }

    public IBattleshipGameBuilder SetAreaSize(int x, int y)
    {
        _areaSize = new AreaSize(x, y);
        return this;
    }
    
    public IBattleshipGameBuilder AddSecondPlayer(string name)
    {
        _player2Name = name ?? throw new ArgumentNullException(nameof(name));
        return this;
    }

    public IBattleshipGameBuilder SetCarriers(Carrier carrier1, Carrier carrier2)
    {
        _player1Carrier = carrier1 ?? throw new ArgumentNullException(nameof(carrier1));
        _player2Carrier = carrier2 ?? throw new ArgumentNullException(nameof(carrier2));
        return this;
    }
    
    public IBattleshipGameBuilder SetBattleships(Battleship battleship1, Battleship battleship2)
    {
        _player1Battleship = battleship1 ?? throw new ArgumentNullException(nameof(battleship1));
        _player2Battleship = battleship2 ?? throw new ArgumentNullException(nameof(battleship2));
        return this;
    }
    
    public IBattleshipGameBuilder SetDestroyers(Destroyer destroyer1, Destroyer destroyer2)
    {
        _player1Destroyer = destroyer1 ?? throw new ArgumentNullException(nameof(destroyer1));
        _player2Destroyer = destroyer2 ?? throw new ArgumentNullException(nameof(destroyer2));
        return this;
    }
    
    public IBattleshipGameBuilder SetSubmarines(Submarine submarine1, Submarine submarine2)
    {
        _player1Submarine = submarine1 ?? throw new ArgumentNullException(nameof(submarine1));
        _player2Submarine = submarine2 ?? throw new ArgumentNullException(nameof(submarine2));
        return this;
    }
    
    public IBattleshipGameBuilder SetPatrolBoats(PatrolBoat patrolBoat1, PatrolBoat patrolBoat2)
    {
        _player1PatrolBoat = patrolBoat1 ?? throw new ArgumentNullException(nameof(patrolBoat1));
        _player2PatrolBoat = patrolBoat2 ?? throw new ArgumentNullException(nameof(patrolBoat2));
        return this;
    }
    
    public BattleshipGame Build()
    {
        var player1 = new Player.Player(
            _player1Name, 
            new PlayerShips(
                _player1Carrier, 
                _player1Battleship, 
                _player1Destroyer, 
                _player1Submarine, 
                _player1PatrolBoat));
        
        var player2 = new Player.Player(
            _player2Name, 
            new PlayerShips(
                _player2Carrier,
                _player2Battleship,
                _player2Destroyer,
                _player2Submarine,
                _player2PatrolBoat));
        
        return new BattleshipGame(_areaSize, player1, player2);
    }
}