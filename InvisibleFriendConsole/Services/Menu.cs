

namespace InvisibleFriendConsole.Services{

    public class Menu{

        public static List<string> GetMenu(int? optionMenu){
            var menu = new List<string>();

            if (optionMenu.HasValue){
                string subMenuName = optionMenu == 1 ? "amigo" : optionMenu == 2 ? "juego" : "configuración correo";
                
                menu.Add($"Submenu {subMenuName}:");
                menu.Add("1. Obtener");
                menu.Add("2. Nuevo");
                menu.Add("3. Modificar");
                menu.Add("4. Eliminar");
                menu.Add("------------------------");
                menu.Add("9. Volver");
                menu.Add(string.Empty);
                menu.Add("Por favor, introduzca uno de los posibles valores:");
            }
            else {
                menu.Add("Menu:");
                menu.Add("1. Amigos");
                menu.Add("2. Juego");
                menu.Add("3. Configuración correo");
                menu.Add("------------------------");
                menu.Add("9. Salir");
                menu.Add(string.Empty);
                menu.Add("Por favor, introduzca uno de los posibles valores:");
            }   

            return menu;
        }

        public static void PaintMenu(List<string> menu) {
            menu.ForEach(menuOption => {
                Console.WriteLine(menuOption);
            });
        }
    }

}