using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;

namespace InvisibleFriendLibrary.Entities;

[Serializable]
public class SmtpConfiguration {

    #region Constants

    private const string pathToSaveFile = @"../Data/smpt.json";

    #endregion

    #region Properties

    public string Smtp { get; set; } = string.Empty;

    public string User { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool Ssl { get; set; }

    public int Port {get;set;}

    #endregion

    #region Methods

    public SmtpClient GetClient(){
        return new SmtpClient(this.Smtp)
        {
            Port = this.Port,
            Credentials = new NetworkCredential(this.User, this.Password),
            EnableSsl = this.Ssl
        };
    }

    public void Save() {
        var json = Utils.ToJson<SmtpConfiguration>(this);
        Utils.WriteInFile(pathToSaveFile, json);  
    }

    public static SmtpConfiguration? GetFromDatabase(){
        SmtpConfiguration? smtpCofniguration = null;
        var database = DataBase.Get();
        if (database != null && database.SmtpConfiguration != null){
            smtpCofniguration = database.SmtpConfiguration;
        }
        return smtpCofniguration;
    }

    #endregion
}