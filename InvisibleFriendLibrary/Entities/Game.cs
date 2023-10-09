namespace InvisibleFriendLibrary;

[Serializable]
public class Game: Item {

#region Properties
    public DateTime StartDate { get; set; }
    public List<Friend> Friends { get; set; } = new List<Friend>();
    public decimal Budget { get; set; }
    public DateTime GivePresent {get;set;}
#endregion

#region Methods

public void Play(){
        
}

#endregion

}