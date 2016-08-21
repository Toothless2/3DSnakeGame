using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Snake
{
    public class GameOver : MonoBehaviour
    {
        public GameObject gameOverUI;

        void Start()
        {
            SetEvents();
        }

        void SetEvents()
        {
            EventHandler.eventHandler.endGamelowHealthEvent += EndGame;
            EventHandler.eventHandler.endGameCollisionEvent += EndGame;

            EventHandler.eventHandler.endGameCollisionEvent += CollisionEndText;
            EventHandler.eventHandler.endGamelowHealthEvent += LowHealthText;
        }

        //always called no matter how the game is ended
        void EndGame()
        {
            StopTime();
            ShowUI();
        }

        //2 methods set the correct text for the loss condition
        void CollisionEndText()
        {
            gameOverUI.GetComponentInChildren<Text>().text = "Stop Hitting Yourself";
        }

        void LowHealthText()
        {
            gameOverUI.GetComponentInChildren<Text>().text = "You Ran out of Fire";
        }

        //shows the game over UI
        void ShowUI()
        {
            ReleaseMouse();
            gameOverUI.SetActive(true);
        }

        //releases controll of the mouse
        void ReleaseMouse()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //stops time
        void StopTime()
        {
            Time.timeScale = 0;
        }

        //starts time and reloads the level
        public void ReloadLevel()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("scene");
        }
        
        //exits the game
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}