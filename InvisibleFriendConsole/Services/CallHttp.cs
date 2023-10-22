
using System.Text.Json;
using InvisibleFriendLibrary.Entities;

namespace InvisibleFriendConsole.Services{

    public class CallHttp{

        public  List<T>? Get<T>(){
            var httpResponse = new HttpClient().GetAsync(GetUrl<T>()).Result;
            var result = httpResponse.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrEmpty(result)){
                return new List<T>();
            }
            return JsonSerializer.Deserialize<List<T>>(result);
        }

        public  HttpResponseMessage Post<T>(T Item){
            var contentString = JsonSerializer.Serialize(Item);
            var content = new StringContent(contentString);
            return new HttpClient().PostAsync(GetUrl<T>(), content).Result;
        }

        public  HttpResponseMessage Put<T>(T Item){
            var contentString = JsonSerializer.Serialize(Item);
            var content = new StringContent(contentString);
            return new HttpClient().PutAsync(GetUrl<T>(), content).Result;
        }

        public void Delete<T>(int Id){
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
    }

}
