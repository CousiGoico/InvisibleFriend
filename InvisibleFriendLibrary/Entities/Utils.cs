using System.Text.Json;

namespace InvisibleFriendLibrary.Entities;

public class Utils{

    #region Methods
    public static void SendEmail(SmtpConfiguration configuration, string sender, string body){
        configuration.GetClient().Send("email", "recipient", sender, body);
    }    

    public static string ToJson<T>(T objectToJson){
        return JsonSerializer.Serialize(objectToJson);
    }

    public static void WriteInFile(string fileName, string text){
        File.WriteAllText(fileName, text);
    }

    #endregion
}