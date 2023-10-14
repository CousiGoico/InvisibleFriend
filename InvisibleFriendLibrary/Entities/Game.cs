using System;
using System.Text;

namespace InvisibleFriendLibrary.Entities;

[Serializable]
public class Game: Item {

#region Properties
    public DateTime StartDate { get; set; }
    public List<Friend> Friends { get; set; } = new List<Friend>();
    public decimal Budget { get; set; }
    public DateTime DateGivePresent {get;set;}
    public string Location { get; set; } = string.Empty;
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
        var randomId = numberRandom.Next(minimumNumber, maximumNumber);
        if (friend.CoupleId > 0 && randomId == friend.CoupleId){
             randomId = numberRandom.Next(minimumNumber, maximumNumber);
        }
        friend.SetFriendToGivePresent(this.Friends.First(x => x.Id == randomId));
    });
}

private void SendEmails() {
    this.Friends.ForEach(friend => { 
        var body = friend.ToEmail();
        body.Replace("{{name}}", this.Name);
        body.Replace("{{rules}}", this.GetRules());
        var smtpConfiguration = SmtpConfiguration.GetFromDatabase();
        if (smtpConfiguration != null){
            Utils.SendEmail(smtpConfiguration, friend.Email, body); 
        }
        
    });
}

private string GetRules() {
    var rules = new StringBuilder();

    rules.Append($"<label>Las reglas de este sorteo son:<label><br />");
    rules.Append("<ul>");
    rules.Append($"<li>El presupuesto del regalo debe ser aproximado a {this.Budget} €.</li>");
    rules.Append($"<li>Se debe entregar el regalo antes del {this.DateGivePresent.ToShortDateString()} a las {this.DateGivePresent.ToLongTimeString()}.</li>");
    rules.Append($"<li>El lugar donde se debe dejar el regalo es: {this.Location}.</li>");
    rules.Append("</ul><br /><br />");

    return rules.ToString();
}

#endregion

}