using UnityEngine;
using System.Collections;

namespace Snake
{
    public class Highscores : MonoBehaviour
    {
        //http://dreamlo.com/lb/pCdeM5YvUkaQBwSxihwP3wdiXAMMftAEGxq28AzDoymA
        string privateCode = "pCdeM5YvUkaQBwSxihwP3wdiXAMMftAEGxq28AzDoymA";
        string publicCode = "57e65ef68af6030bfcb83776";
        string URL = "http://dreamlo.com/lb/";

        public Highscore[] highscoresList;
        static Highscores instance;

        void Awake()
        {
            instance = this;
            DownloadHighscores();
        }

        public static void UploadScores(string username, int score)
        {
            instance.StartCoroutine(instance.Upload(username, score));
        }

        IEnumerator Upload(string username, int score)
        {
            //addes the score
            WWW www = new WWW(URL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
            //waites untill it has finished
            yield return www;

            //checks that their was no error
            if (string.IsNullOrEmpty(www.error))
            {
                DownloadHighscores();
                //print("Uploaded Score Succesfully");
            }
            else
            {
                Debug.LogWarning("Upload Error: " + www.error);
            }
        }

        public void DownloadHighscores()
        {
            StartCoroutine(Download());
        }

        IEnumerator Download()
        {
            //downloads the score
            WWW www = new WWW(URL + publicCode + "/pipe/");
            //waits till it as been downloaded
            yield return www;

            //checks for a download error
            if(string.IsNullOrEmpty(www.error))
            {
                FormatHighscores(www.text);
            }
            else
            {
                Debug.LogWarning("Error Downloading: " + www.error);
            }
        }

        //formats the highscore
        void FormatHighscores(string textStream)
        {
            string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            highscoresList = new Highscore[entries.Length];

            for(int i = 0; i < entries.Length; i++)
            {
                string[] entiryInfo = entries[i].Split(new char[] { '|' }, System.StringSplitOptions.RemoveEmptyEntries);

                highscoresList[i].name = entiryInfo[0];
                highscoresList[i].score = int.Parse(entiryInfo[1]);
            }

            GetComponent<Displayhighscores>().UpdateHighscoresUI(highscoresList);
        }
    }

    public struct Highscore
    {
        public string name;
        public int score;
    }
}