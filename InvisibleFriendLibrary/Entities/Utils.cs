using System.Text.Json;

namespace InvisibleFriendLibrary.Entities;

public class Utils{

    #region Methods
    public static void SendEmail(SmtpConfiguration? configuration, string sender, string body){
        if (configuration != null) {
            configuration.GetClient().Send("email", "recipient", sender, body);
        }
    }    

    public static string ToJson<T>(T objectToJson){
        return JsonSerializer.Serialize(objectToJson);
    }

    public static T? ToType<T>(string json){
        return JsonSerializer.Deserialize<T>(json);
    }

    public static void WriteInFile(string fileName, string text){
        File.WriteAllText(fileName, text);
    }

    public static string ReadFromFile(string fileName){
        return File.ReadAllText(fileName);
    }

    #endregion
}