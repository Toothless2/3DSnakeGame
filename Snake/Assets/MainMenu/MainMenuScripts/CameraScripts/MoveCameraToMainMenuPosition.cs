using UnityEngine;
using System.Collections;

namespace Snake
{
    public class MoveCameraToMainMenuPosition : MonoBehaviour
    {
        public GameObject mainMenuPosition;
        public GameObject mainMenuRotation;
        public BackToMainMenu loadMenu;

        public bool returnToMenu;

        void Awake()
        {
            GetComponent<Camera>().enabled = false;
            transform.position = mainMenuPosition.transform.position;
            transform.LookAt(mainMenuRotation.transform);
            GetComponent<Camera>().enabled = true;
        }

        public void ReturnToMain()
        {
            returnToMenu = true;
            loadMenu.HideOptions();
        }

        void Update()
        {
            if(returnToMenu)
            {
                Return();

                if(Vector3.Distance(transform.position, mainMenuPosition.transform.position) < 0.1f)
                {
                    returnToMenu = false;
                    loadMenu.ShowMain();
                    GetComponent<Transform>().position = mainMenuPosition.transform.position;
                    transform.LookAt(mainMenuRotation.transform);
                }
            }
        }

        void Return()
        {
            GetComponent<Transform>().position = Vector3.MoveTowards(transform.position, mainMenuPosition.transform.position, (Time.deltaTime * 20f));
            GetComponent<Transform>().rotation = Quaternion.Slerp(transform.rotation, mainMenuPosition.transform.rotation, (Time.deltaTime * 5f));
        }
    }
}