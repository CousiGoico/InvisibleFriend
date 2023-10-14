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
        var friends = new List<Friend>();
        var database = DataBase.Get();
        if (database != null && database.Friends != null){
            friends = database.Friends;
        }
        return friends;
    }

    [HttpPost(Name = "PostFriend")]
    public ActionResult Post(Friend friend)
    {
        var database = DataBase.Get();
        if (database != null){
            if (database.Friends == null){
                database.Friends = new List<Friend>();
            }
            database.Friends.Add(friend);
            database.Save();
        }
        return Ok();
    }

    [HttpPut(Name = "PutFriend")]
    public ActionResult Put(Friend friend)
    {
        var database = DataBase.Get();
        if (database != null && database.Friends != null){
            var friendFound = database.Friends.FirstOrDefault(x => x.Id == friend.Id);
            if (friendFound != null){
                friendFound.Surname = friend.Surname;
                friendFound.Name = friend.Name;
                friendFound.Email = friend.Email;
                friendFound.Couple = friend.Couple;
                database.Save();
            }
        }
        return Ok();
    }

    [HttpDelete(Name = "DeleteFriend")]
    public ActionResult Delete(Friend friend)
    {
        var database = DataBase.Get();
        if (database != null && database.Friends != null){
            var friendFound = database.Friends.FirstOrDefault(x => x.Id == friend.Id);
            if (friendFound != null){
                database.Friends.Remove(friendFound);
                database.Save();
            }
        }
        return Ok();
    }
}
