using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class MenuButtons : MonoBehaviour
    {
        public GameObject menu;
        public GameObject options;
        public GameObject keybindings;

        private bool isMenuOpen;

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(!isMenuOpen)
                {
                    OpenMenu();
                    isMenuOpen = true;
                }
                else
                {
                    CloseMenu();
                    isMenuOpen = false;
                }
            }
        }

        void OpenMenu()
        {
            Time.timeScale = 0;
            ShowMenu();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        void CloseMenu()
        {
            HideMenu();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1;
        }

        public void ShowMenu()
        {
            menu.SetActive(true);
        }

        public void HideMenu()
        {
            menu.SetActive(false);
        }

        public void ShowOptions()
        {
            options.SetActive(true);
        }

        public void HideOptions()
        {
            options.SetActive(false);
        }

        public void ShowKeybindings()
        {
            keybindings.SetActive(true);
        }

        public void HideKeybindings()
        {
            keybindings.SetActive(false);
        }

        public void Restart()
        {
            SceneManager.LoadScene("SinglePlayer");
        }

        public void BackToMain()
        {
            Time.timeScale = 1;
            Debug.Assert(Time.timeScale == 1);

            SceneManager.LoadScene("MainMenu");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}