using UnityEngine;
using System.Collections;

namespace Snake
{
    public class MoveCameraToOptionsMenuPositon : MonoBehaviour
    {
        public GameObject optionsMenuPosition;
        public GameObject optionsMenuRotation;
        public SwitchMenus keyb;

        public bool returnToMenu;

        public void ToOptions()
        {
            returnToMenu = true;
            keyb.HideMain();
            keyb.HideKeybindings();
        }

        void Update()
        {
            if (returnToMenu)
            {
                Return();

                if (Vector3.Distance(transform.position, optionsMenuPosition.transform.position) < 0.1f)
                {
                    returnToMenu = false;
                    keyb.ShowOptions();
                    GetComponent<Transform>().position = optionsMenuPosition.transform.position;
                    transform.LookAt(optionsMenuRotation.transform);
                }
            }
        }

        void Return()
        {
            GetComponent<Transform>().position = Vector3.MoveTowards(transform.position, optionsMenuPosition.transform.position, (Time.deltaTime * 20f));
            GetComponent<Transform>().rotation = Quaternion.Slerp(transform.rotation, optionsMenuPosition.transform.rotation, (Time.deltaTime * 5f));
        }
    }
}