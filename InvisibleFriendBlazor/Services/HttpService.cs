using System.Net.Http.Json;

namespace InvisibleFriendBlazor.Services{

    public static class HttpService{

        public static async Task<T?> Get<T>(string url){
            using (var client = new HttpClient())
            {
                return await client.GetFromJsonAsync<T>(url);
            }

        }
    }
}