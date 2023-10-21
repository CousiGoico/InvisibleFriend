using System.ComponentModel.DataAnnotations;
using InvisibleFriendLibrary.Entities;
using System.Text.Json;

namespace InvisibleFriendConsole;
class Program
{
    static void Main(string[] args)
    {
        Root();
    }

    private static void Root() {
        var optionMenuId = ShowMainMenu();
        Int32 subOptionMenuId = ShowSuMenu(optionMenuId);
        processSubMenu(optionMenuId, subOptionMenuId);
    }

    private static Int32 ShowMainMenu() {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Amigos");
        Console.WriteLine("2. Juego");
        Console.WriteLine("3. Configuración correo");
        Console.WriteLine("4. Salir");
        Console.WriteLine("Por favor, introduzca el código de una opción de menú:");
        var optionMenu = Console.ReadLine();
        var isCorrect = Int32.TryParse(optionMenu, out int optionMenuId);
        if (optionMenuId == 4){
            Environment.Exit(0);
        }
        if (isCorrect && optionMenuId > 0 && optionMenuId < 4) {
            return optionMenuId;
        }
        else {
            Console.WriteLine("Opción incorrecta. Por favor, vuelva a intentarlo.");
            return ShowMainMenu();
        }
    }

    private static Int32 ShowSuMenu(Int32 typeId) {
        string subMenuName = typeId == 1 ? "amigo" : typeId == 2 ? "juego" : "configuración correo";
         Console.WriteLine($"Submenu {subMenuName}:");
        Console.WriteLine("1. Obtener");
        Console.WriteLine("2. Nuevo");
        Console.WriteLine("3. Modificar");
        Console.WriteLine("4. Eliminar");
        Console.WriteLine("5. Salir");
        Console.WriteLine("Por favor, introduzca el código de una opción de menú:");
        var optionMenu = Console.ReadLine();
        var isCorrect = Int32.TryParse(optionMenu, out int optionMenuId);
        if (optionMenuId == 5){
            Root();
        }
        if (isCorrect && optionMenuId > 0 && optionMenuId < 6) {
            return optionMenuId;
        }
        else {
            Console.WriteLine("Opción incorrecta. Por favor, vuelva a intentarlo.");
            return ShowMainMenu();
        }
    }

    private static void processSubMenu(Int32 optionMenuId, Int32 subMenuId){
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

    private static List<T>? Get<T>(){
        var httpResponse = new HttpClient().GetAsync(GetUrl<T>()).Result;
        var result = httpResponse.Content.ReadAsStringAsync().Result;
        if (string.IsNullOrEmpty(result)){
            return new List<T>();
        }
        return JsonSerializer.Deserialize<List<T>>(result);
    }

    private static HttpResponseMessage Post<T>(T Item){
        var contentString = JsonSerializer.Serialize(Item);
        var content = new StringContent(contentString);
        return new HttpClient().PostAsync(GetUrl<T>(), content).Result;
    }

    private static HttpResponseMessage Put<T>(T Item){
        var contentString = JsonSerializer.Serialize(Item);
        var content = new StringContent(contentString);
        return new HttpClient().PutAsync(GetUrl<T>(), content).Result;
    }

    private static void Delete<T>(int Id){
        var contentString = JsonSerializer.Serialize(Id);
        var content = new StringContent(contentString);
        //return new HttpClient().DeleteAsync()GetUrl<T>(), content).Result;
    }

    private static void CallAPI(string url, string verb){

    }

    private static string GetUrl<T>(){
        Type typeParameterType = typeof(T);
        return $"https://localhost:7096/api/{typeParameterType.Name}";
    }

}
