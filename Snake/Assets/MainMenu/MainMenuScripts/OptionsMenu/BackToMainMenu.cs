using UnityEngine;
using System.Collections;

namespace Snake
{
    public class BackToMainMenu : MonoBehaviour
    {
        public GameObject mainMenu;

        public void ToMainMenu()
        {
            gameObject.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}