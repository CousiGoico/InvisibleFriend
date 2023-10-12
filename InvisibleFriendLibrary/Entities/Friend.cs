
using System.Text;

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
    var body = this.ToEmail();
    var configuration = new SmtpConfiguration();
    Utils.SendEmail(configuration, sender, body);
}

public string ToEmail(){
    var html = new StringBuilder();

    html.Append($"<label>Hola {this.Name}, <br /><br />te informo que te han invitado a participar en un sorteo de Amigo Invisible {{name}}.<label><br /><br />");
    html.Append("{{reglas}}");
    html.Append($"<label style='color:red; font-weight:bold;'>* La persona que te ha tocado regalar es: {this.FriendToGivePresent?.Name}<label>");

    return html.ToString();
}

#endregion

}