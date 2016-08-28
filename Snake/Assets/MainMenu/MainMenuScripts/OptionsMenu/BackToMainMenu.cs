using UnityEngine;
using System.Collections;

namespace Snake
{
    public class BackToMainMenu : MonoBehaviour
    {
        public GameObject mainMenu;
        public GameObject keybindingsMenu;

        public void HideOptions()
        {
            gameObject.SetActive(false);
        }

        public void ShowOptions()
        {
            gameObject.SetActive(true);
        }

        public void ShowMain()
        {
            mainMenu.SetActive(true);
        }

        public void ToKeyBindings()
        {
            keybindingsMenu.SetActive(true);
        }

        public void HideKeybindings()
        {
            keybindingsMenu.SetActive(false);
        }
    }
}