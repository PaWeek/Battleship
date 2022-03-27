using BattleShip.GameEngine.Game;

namespace BattleShip.BFF.Simulator;

public interface IBattleshipGameSimulator
{
    BattleshipGame SimulateGame(string player1Name, string player2Name);
}