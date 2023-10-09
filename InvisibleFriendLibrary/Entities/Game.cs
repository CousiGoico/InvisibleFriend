namespace InvisibleFriendLibrary

[Serializable]
public class Game: Item {

#region Properties
    public DateTime StartDate { get; set; }
    public List<Friend> Friends { get; set; }
    public decimal Budget { get; set; }
    public DateTime GivePresent {get;set;}
#endregion

}