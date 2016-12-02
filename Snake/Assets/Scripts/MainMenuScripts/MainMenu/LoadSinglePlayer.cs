using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class LoadSinglePlayer : MonoBehaviour
    {
        public void PlayeSinglePlayer()
        {
            SceneManager.LoadScene("SinglePlayer");
        }
    }
}