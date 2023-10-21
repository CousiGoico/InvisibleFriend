using System.ComponentModel.DataAnnotations;
using InvisibleFriendLibrary.Entities;

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
            break;
            case 2:
            break;
            case 3:
            break;
            case 4:
            break;
        }
    }

    private static List<T> Get<T>(){
return new List<T>();
    }

    private static void Post<T>(){
        
    }

    private static void Put<T>(){}

    private static void Delete<T>(){}

    private static void CallAPI(string url, string verb){

    }

}
