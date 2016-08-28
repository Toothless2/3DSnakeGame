using UnityEngine;
using System.Collections;

namespace Snake
{
    public class CurrentKeybindings
    {
        public static int lookSensitivity;
        public static KeyCode openMenu;
        public static KeyCode speedUp;
        public static KeyCode speedDown;

        public CurrentKeybindings(int sensitivity, KeyCode up, KeyCode down)
        {
            lookSensitivity = sensitivity;
            speedUp = up;
            speedDown = down;
        }
    }
}