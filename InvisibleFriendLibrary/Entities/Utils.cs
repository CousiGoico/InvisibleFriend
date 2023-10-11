using System.Net;
using System.Net.Mail;

namespace InvisibleFriendLibrary;

public class Utils{
    public static void SendEmail(string sender, string body){
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("username", "password"),
            EnableSsl = true
        };
            
        smtpClient.Send("email", "recipient", "subject", "body");
    }    
}