using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class LoadSinglePlayer : MonoBehaviour
    {
        public void PlayeSinglePlayer()
        {
            Constants.gameMode = EnumGameMode.CLASSIC;
            SceneManager.LoadScene("SinglePlayer");
        }
    }
}