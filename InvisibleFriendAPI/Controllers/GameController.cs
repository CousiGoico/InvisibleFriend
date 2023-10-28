using Microsoft.AspNetCore.Mvc;
using InvisibleFriendLibrary.Entities;
using InvisibleFriendLibrary.Services;

namespace InvisibleFriendAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly ILogger<GameController> _logger;
    private readonly IGameService iGameService;

    public GameController(ILogger<GameController> logger, IGameService iGameService)
    {
        this._logger = logger;
        this.iGameService = iGameService;
    }

    [HttpGet(Name = "GetGame")]
    public IEnumerable<Game> Get()
    {
        var games = iGameService.Get();
        return games;
    }

    [HttpPost(Name = "PostGame")]
    public ActionResult Post(Game game)
    {
        iGameService.Post(game);
        return Ok();
    }

    [HttpPut(Name = "PutGame")]
    public ActionResult Put(int gameId, DateTime startDate, List<Friend> friends, DateTime dateGivePresent, string location, decimal budget)
    {
        var game = new Game {
            Id = gameId,
            StartDate = startDate,
            Friends =friends,
            DateGivePresent = dateGivePresent,
            Location = location,
            Budget = budget
        };
         iGameService.Put(game);
        return Ok();
    }

    [HttpDelete(Name = "DeleteGame")]
    public ActionResult Delete(int id)
    {
        iGameService.Delete(id);
        return Ok();
    }
}
