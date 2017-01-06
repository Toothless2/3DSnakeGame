using UnityEngine;

namespace Snake
{
	public static class Constants
    {
        public static EnumGameMode gameMode;

        public static string username;

        public static bool snowing;
        public static bool firstLoad = true;

        //Keybindings
        public static int lookSensitivity;
        //TODO Add
        public static KeyCode openMenu;
        public static KeyCode speedUp;
        public static KeyCode speedDown;

        //Options
        public static int FOV;
        
        public static LayerMask Layer()
        {
            switch (gameMode)
            {
                case EnumGameMode.CLASSIC:
                    return LayerMask.NameToLayer("ClassicLayer");
                case EnumGameMode.DUELING:
                    return LayerMask.NameToLayer("DuelingLayer");
                case EnumGameMode.HELL:
                    return LayerMask.NameToLayer("HellLayer");
                default:
                    return LayerMask.NameToLayer("ClassicLayer");
            }
        }
    }
}