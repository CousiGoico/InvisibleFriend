using Microsoft.AspNetCore.Mvc;
using InvisibleFriendLibrary.Entities;
using InvisibleFriendLibrary.Repositories;
using InvisibleFriendLibrary.Services;

namespace InvisibleFriendAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FriendController : ControllerBase
{
    private readonly ILogger<FriendController> _logger;
    private IFriendService friendService;

    public FriendController(ILogger<FriendController> logger, IFriendService friendService)
    {
        _logger = logger;
        this.friendService = friendService;
    }

    [HttpGet(Name = "GetFriends")]
    public IEnumerable<Friend> Get()
    {
        return this.friendService.Get();
    }

    [HttpPost(Name = "PostFriend")]
    public ActionResult Post(Friend friend)
    {
        this.friendService.Post(friend);
        return Ok();
    }

    [HttpPut(Name = "PutFriend")]
    public ActionResult Put(int friendId, string name, string surname, string email, int coupleId)
    {
        var friend = new Friend {
            Id = friendId,
            Name = name,
            Surname = surname,
            Email = email,
            CoupleId = coupleId
        };
        this.friendService.Put(friend);
        return Ok();
    }

    [HttpDelete(Name = "DeleteFriend")]
    public ActionResult Delete(int id)
    {
        this.friendService.Delete(id);
        return Ok();
    }
}
