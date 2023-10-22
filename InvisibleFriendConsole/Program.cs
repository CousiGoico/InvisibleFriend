using System.ComponentModel.DataAnnotations;
using InvisibleFriendLibrary.Entities;
using System.Text.Json;
using InvisibleFriendConsole.Services;
using System.Reflection;

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
        Menu.PaintMenu(Menu.GetMenu(null));
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

    private static Int32 ShowSuMenu(int menuId) {
        Menu.PaintMenu(Menu.GetMenu(menuId));
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
            return ShowSuMenu(menuId);
        }
    }

    private static void processSubMenu(Int32 optionMenuId, Int32 subMenuId){
        var callHttp = new CallHttp();
        Process(optionMenuId, subMenuId);
    }

    private static void Process(int optionMenuId, int subMenuId){
        var callHttp = new CallHttp();
        Type type = optionMenuId == 1 ? typeof(Friend) : optionMenuId == 1 ? typeof(Game) : typeof(SmtpConfiguration);
        switch(subMenuId) {
            case 1:
            MethodInfo? infoMethodGet = typeof(CallHttp).GetMethod("Get");
            if (infoMethodGet != null){
                MethodInfo method = infoMethodGet.MakeGenericMethod(type);
                var items = method.Invoke(null, null);
            }
            break;
            case 2:
            MethodInfo? infoMethodPost = typeof(CallHttp).GetMethod("Post");
            if (infoMethodPost != null){
                MethodInfo method = infoMethodPost.MakeGenericMethod(type);
                var items = method.Invoke(null, null);
            }
            break;
            case 3:
            MethodInfo? infoMethodPut = typeof(CallHttp).GetMethod("Put");
            if (infoMethodPut != null){
                MethodInfo method = infoMethodPut.MakeGenericMethod(type);
                var items = method.Invoke(null, null);
            }
            break;
            case 4:
            MethodInfo? infoMethodDelete = typeof(CallHttp).GetMethod("Delete");
            if (infoMethodDelete != null){
                MethodInfo method = infoMethodDelete.MakeGenericMethod(type);
                var items = method.Invoke(null, null);
            }
            break;
        }
    }

}
