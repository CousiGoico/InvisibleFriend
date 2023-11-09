using InvisibleFriendLibrary.Entities;
using Microsoft.JSInterop;

namespace InvisibleFriendBlazor.Helpers{

    public static class Extensions
    {
        public static Task SetInSessionStorage(this IJSRuntime js, string key, string content) => js.InvokeAsync<object>("sessionStorage.setItem", key, content).AsTask();

        public static Task<string> GetFromSessionStorage(this IJSRuntime js, string key) => js.InvokeAsync<string>("sessionStorage.getItem", key).AsTask();

        public static Task RemoveItem(this IJSRuntime js, string key) => js.InvokeAsync<object>("sessionStorage.removeItem", key).AsTask();

        public static Task<WindowsDimensions> GetDimensions(this IJSRuntime js) => js.InvokeAsync<WindowsDimensions>("getDimensions").AsTask();

        public static Task<bool> Confirm(this IJSRuntime js, string message) => js.InvokeAsync<bool>("confirm", message).AsTask();
    }
}