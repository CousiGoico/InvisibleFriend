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

    [HttpPut(Name = "PutGame")]
    public ActionResult Put(int gameId, DateTime startDate, List<Friend> friends, DateTime dateGivePresent, string location, decimal budget)
    {
         var database = DataBase.Get();
        if (database != null && database.Games != null){
            var gameFound = database.Games.FirstOrDefault(x => x.Id == gameId);
            if (gameFound != null){
                gameFound.StartDate = startDate;
                gameFound.Friends = friends;
                gameFound.DateGivePresent = dateGivePresent;
                gameFound.Location = location;
                gameFound.Budget = budget;
                database.Save();
            }
        }
        return Ok();
    }

    [HttpDelete(Name = "DeleteGame")]
    public ActionResult Delete(int id)
    {
        var database = DataBase.Get();
        if (database != null && database.Games != null){
            var gameFound = database.Games.FirstOrDefault(x => x.Id == id);
            if (gameFound != null){
                database.Games.Remove(gameFound);
                database.Save();
            }
        }
        return Ok();
    }
}
