
using System.Text.Json;
using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendConsole.Services{

public class CallHttp{


private  List<T>? Get<T>(){
        var httpResponse = new HttpClient().GetAsync(GetUrl<T>()).Result;
        var result = httpResponse.Content.ReadAsStringAsync().Result;
        if (string.IsNullOrEmpty(result)){
            return new List<T>();
        }
        return JsonSerializer.Deserialize<List<T>>(result);
    }

    private  HttpResponseMessage Post<T>(T Item){
        var contentString = JsonSerializer.Serialize(Item);
        var content = new StringContent(contentString);
        return new HttpClient().PostAsync(GetUrl<T>(), content).Result;
    }

    private  HttpResponseMessage Put<T>(T Item){
        var contentString = JsonSerializer.Serialize(Item);
        var content = new StringContent(contentString);
        return new HttpClient().PutAsync(GetUrl<T>(), content).Result;
    }

    private void Delete<T>(int Id){
        var contentString = JsonSerializer.Serialize(Id);
        var content = new StringContent(contentString);
        //return new HttpClient().DeleteAsync()GetUrl<T>(), content).Result;
    }

    private static void CallAPI(string url, string verb){

    }

    public string GetUrl<T>(){
        Type typeParameterType = typeof(T);
        return $"https://localhost:7096/api/{typeParameterType.Name}";
    }

    public void Process(int optionMenuId, int subMenuId){
        switch(subMenuId){
            case 1:
            if (optionMenuId == 1){
                var items = Get<Friend>();
            }
            else if (optionMenuId == 2){
                var items = Get<Game>();
            }
            else {
                var items = Get<SmtpConfiguration>();
            }
            break;
            case 2:
            break;
            case 3:
            break;
            case 4:
            break;
        }
    }
}

}
