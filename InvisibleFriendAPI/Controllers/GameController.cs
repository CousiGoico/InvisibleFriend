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
        return new List<Game>();
    }

    [HttpPost(Name = "PostGame")]
    public ActionResult Post(Game game)
    {
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
