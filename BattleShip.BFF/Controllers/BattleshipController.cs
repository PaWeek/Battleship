using BattleShip.BFF.Models;
using BattleShip.BFF.Simulator;
using BattleShip.GameEngine.Game;
using BattleShip.GameEngine.GameBuilder;
using BattleShip.GameEngine.Plaxyer;
using BattleShip.GameEngine.Ships;
using Microsoft.AspNetCore.Mvc;
using Point = BattleShip.GameEngine.Area.Point;

namespace BattleShip.BFF.Controllers;

[ApiController]
[Route("[controller]")]
public class BattleshipController
{
    private readonly IBattleshipGameSimulator _battleshipGameSimulator;

    public BattleshipController(IBattleshipGameSimulator battleshipGameSimulator)
    {
        _battleshipGameSimulator = battleshipGameSimulator;
    }

    [HttpPost("Games")]
    public ActionResult<Guid> SetupNewGame([FromBody] SetupGame setupGame)
    {
        var game = _battleshipGameSimulator.SimulateGame(setupGame.Player1Name, setupGame.Player2Name);
        GamesBoard.AddGame(game);
        return new OkObjectResult(game.Id);
    }

    [HttpGet("Games/{gameId}")]
    public ActionResult<BattleshipGame> GetGame(Guid gameId)
    {
        var game = GamesBoard.GetGame(gameId);
        
        if (game == null)
            return new BadRequestResult();

        return new OkObjectResult(game);
    }
}