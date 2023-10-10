
namespace InvisibleFriendLibrary;

[Serializable]
public class Friend : Item {

#region Properties
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Friend? Couple { get; set; } = null;
    public Friend? FriendToGivePresent {get;set;} = null;
#endregion

#region Methods

public void SendEmail(){
    if (this.FriendToGivePresent == null){
        throw new Exception("No tiene amigo a quien dar regalo.");
    }
    var sender = this.FriendToGivePresent.Email;
    var body = "";
    Utils.SendEmail(sender, body);
}

#endregoin

}