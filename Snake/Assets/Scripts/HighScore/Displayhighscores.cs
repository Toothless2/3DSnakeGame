using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Snake
{
    public class Displayhighscores : MonoBehaviour
    {
        public Text[] highscoreBoard;
        float waitTime;

        void Start()
        {
            for (int i = 0; i < highscoreBoard.Length; i++)
            {
                highscoreBoard[i].text = i + 1 + ". Fetching Score...";
            }
        }

        public void UpdateHighscoresUI(Highscore[] highscores)
        {
            StartCoroutine(RefreshHighscores(highscores));
        }

        IEnumerator RefreshHighscores(Highscore[] highscores)
        {
            for (int i = 0; i < highscoreBoard.Length; i++)
            {
                if (i < highscores.Length)
                {
                    highscoreBoard[i].text = (i + 1) + ". " + highscores[i].name + ": " + highscores[i].score;
                }
                else
                {
                    highscoreBoard[i].text = (i + 1) + ". Its Lonley Here :(";
                }
            }
            
            yield return new WaitForSeconds(30);
            GetComponent<Highscores>().DownloadHighscores();
        }
    }
}