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
    Distribute();
    SendEmails();
}

private void Distribute() {
    this.Friends.ForEach(friend => {
        var numberRandom = new Random();
        var minimumNumber = this.Friends.Select(x => x.Id).Min();
        var maximumNumber = this.Friends.Select(x => x.Id).Max();
        var randomId = numberRandom.next(minimumNumber, maximumNumber);
        if (friend.Couple.HasValue() && randomId == friend.Couple.Id){
             randomId = numberRandom.next(minimumNumber, maximumNumber);
        }
        friend.FriendToGivePresent = this.Friends.First(x => x.Id == randomId);
    });
}

private void SendEmails() {
    this.Friends.ForEach(friend => { Utils.SendEmail(friend); });
}

#endregion

}