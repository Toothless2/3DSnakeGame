using UnityEngine;
using System.Collections;

namespace Snake
{
    public class test : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                Highscores.UploadScores("Twig", Random.Range(1, 100));
            }
        }
    }
}
