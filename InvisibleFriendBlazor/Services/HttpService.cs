using System.Net.Http.Json;

namespace InvisibleFriendBlazor.Services{

    public static class HttpService{

        public static async Task<T?> Get<T>(string url){
            using (var client = new HttpClient())
            {
                return await client.GetFromJsonAsync<T>(url);
            }
        }

        public static async Task<HttpResponseMessage> Post<T>(string url, T model){
            using (var client = new HttpClient())
            {
                var content = JsonHelper.toHttpContent(model);
                return await client.PostAsync(url, content);
            }
        }
    }
}