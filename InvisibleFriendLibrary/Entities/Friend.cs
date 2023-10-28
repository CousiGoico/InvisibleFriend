
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using InvisibleFriendLibrary.Repositories;

namespace InvisibleFriendLibrary.Entities;

[Serializable]
public class Friend : Item {

#region Properties
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int CoupleId { get; set; }
    private int FriendToGivePresentId {get;set;} = 0;
#endregion

#region Methods

private static Friend? GetFriend(int id) {
    var database = new DataBaseRepository().Get();    
    Friend? friend = null;
    if (database != null && database.Friends != null){
        friend = database.Friends.FirstOrDefault(x => x.Id == id);
    }
    return friend;
}

public void SendEmail(){
    if (this.FriendToGivePresentId < 1){
        throw new Exception("No tiene amigo a quien dar regalo.");
    }
    var sender = GetFriend(this.FriendToGivePresentId)?.Email;
    var body = this.ToEmail();
    var configuration = SmtpConfiguration.GetFromDatabase();
    if (configuration != null && sender != null){
        Utils.SendEmail(configuration, sender, body);    
    }
}

public string ToEmail(){
    var html = new StringBuilder();

    html.Append($"<label>Hola {this.Name}, <br /><br />te informo que te han invitado a participar en un sorteo de Amigo Invisible {{name}}.<label><br /><br />");
    html.Append("{{reglas}}");
    var friend = GetFriend(this.FriendToGivePresentId);
    html.Append($"<label style='color:red; font-weight:bold;'>* La persona que te ha tocado regalar es: {friend?.Name}<label>");

    return html.ToString();
}

public void SetFriendToGivePresent(Friend friend) {
    this.FriendToGivePresentId = friend.Id;
}

#endregion

}