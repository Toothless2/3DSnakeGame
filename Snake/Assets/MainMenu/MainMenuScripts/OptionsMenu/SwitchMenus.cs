using UnityEngine;
using System.Collections;

namespace Snake
{
    public class SwitchMenus : MonoBehaviour
    {
        public GameObject mainMenu;
        public GameObject optionsMenu;
        public GameObject keybindingsMenu;

        public void HideOptions()
        {
            optionsMenu.SetActive(false);
        }

        public void ShowOptions()
        {
            optionsMenu.SetActive(true);
        }

        public void ShowMain()
        {
            mainMenu.SetActive(true);
        }

        public void HideMain()
        {
            mainMenu.SetActive(false);
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