using BattleShip.GameEngine.Area;
using BattleShip.GameEngine.Game;
using BattleShip.GameEngine.Ships;

namespace BattleShip.GameEngine.GameBuilder;

public interface IBattleshipGameBuilder
{
    IBattleshipGameBuilder AddFirstPlayer(string name);
    IBattleshipGameBuilder AddSecondPlayer(string name);
    IBattleshipGameBuilder SetAreaSize(int x, int y);
    IBattleshipGameBuilder SetCarriers(Carrier carrier1, Carrier carrier2);
    IBattleshipGameBuilder SetBattleships(Battleship battleship1, Battleship battleship2);
    IBattleshipGameBuilder SetDestroyers(Destroyer destroyer1, Destroyer destroyer2);
    IBattleshipGameBuilder SetSubmarines(Submarine submarine1, Submarine submarine2);
    IBattleshipGameBuilder SetPatrolBoats(PatrolBoat patrolBoat1, PatrolBoat patrolBoat2);
    BattleshipGame Build();
}