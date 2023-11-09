namespace InvisibleFriendBlazor{

    public class JsonHelper
    {
        public static T? fromJson<T>(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(json);
        }

        public static T? fromHttpResponseMessage<T>(HttpResponseMessage responseMessage) {
            var text = responseMessage.Content.ReadAsStringAsync().Result;
            return fromJson<T>(text);
        }

        public static string toJson(object instance)
        {
            return System.Text.Json.JsonSerializer.Serialize(instance);
        }

        public static HttpContent toHttpContent(object instance) {
            return new StringContent(toJson(instance), System.Text.Encoding.UTF8, "application/json");
        }
    }
}