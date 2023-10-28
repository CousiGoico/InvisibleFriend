using Microsoft.AspNetCore.Mvc;
using InvisibleFriendLibrary.Entities;
using InvisibleFriendLibrary.Repositories;

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
        var database = new DataBaseRepository().Get();
        if (database != null && database.Friends != null){
            friends = database.Friends;
        }
        return friends;
    }

    [HttpPost(Name = "PostFriend")]
    public ActionResult Post(Friend friend)
    {
        var database = new DataBaseRepository().Get();
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
    public ActionResult Put(int friendId, string name, string surname, string email, int coupleId)
    {
        var database = new DataBaseRepository().Get();
        if (database != null && database.Friends != null){
            var friendFound = database.Friends.FirstOrDefault(x => x.Id == friendId);
            if (friendFound != null){
                friendFound.Surname = surname;
                friendFound.Name = name;
                friendFound.Email = email;
                friendFound.CoupleId = coupleId;
                database.Save();
            }
        }
        return Ok();
    }

    [HttpDelete(Name = "DeleteFriend")]
    public ActionResult Delete(int id)
    {
        var database = new DataBaseRepository().Get();
        if (database != null && database.Friends != null){
            var friendFound = database.Friends.FirstOrDefault(x => x.Id == id);
            if (friendFound != null){
                database.Friends.Remove(friendFound);
                database.Save();
            }
        }
        return Ok();
    }
}
