using BattleShip.GameEngine.Game;

namespace BattleShip.BFF;

public static class GamesBoard
{
    private static List<BattleshipGame> _games = new List<BattleshipGame>();

    public static BattleshipGame? GetGame(Guid id)
        => _games.SingleOrDefault(x => x.Id == id);

    public static void AddGame(BattleshipGame game)
        => _games.Add(game);
}