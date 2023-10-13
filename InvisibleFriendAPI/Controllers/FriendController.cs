using Microsoft.AspNetCore.Mvc;
using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FriendController : ControllerBase
{
    private readonly ILogger<FriendController> _logger;

    public FriendController(ILogger<FriendController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetFriends")]
    public IEnumerable<Friend> Get()
    {
        return new List<Friend>();
    }

    [HttpPost(Name = "PostFriend")]
    public ActionResult Post(Friend friend)
    {
        return Ok();
    }

    [HttpPut(Name = "PutFriend")]
    public ActionResult Put(Friend friend)
    {
        return Ok();
    }

    [HttpDelete(Name = "DeleteFriend")]
    public ActionResult Delete(Friend friend)
    {
        return Ok();
    }
}
