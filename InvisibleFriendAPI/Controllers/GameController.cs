using Microsoft.AspNetCore.Mvc;
using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly ILogger<GameController> _logger;

    public GameController(ILogger<GameController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetGame")]
    public IEnumerable<Game> Get()
    {
        var games = new List<Game>();
        var database = DataBase.Get();
        if (database != null && database.Games != null){
            games = database.Games;
        }
        return games;
    }

    [HttpPost(Name = "PostGame")]
    public ActionResult Post(Game game)
    {
        var database = DataBase.Get();
        if (database != null){
            if (database.Games == null){
                database.Games = new List<Game>();
            }
            database.Games.Add(game);
            database.Save();
        }
        return Ok();
    }

    [HttpPost(Name = "PlayGame")]
    public ActionResult Play(Game game)
    {
        game.Play();
        return Ok();
    }

    [HttpPut(Name = "PutGame")]
    public ActionResult Put(Game game)
    {
        return Ok();
    }

    [HttpDelete(Name = "DeleteGame")]
    public ActionResult Delete(Game game)
    {
        return Ok();
    }
}
