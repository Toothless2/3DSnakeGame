using UnityEngine;
using System.Collections;

namespace Snake
{
    public class MoveCameraToKeybindingsMenu : MonoBehaviour
    {
        public GameObject keybindingsMenuPosition;
        public GameObject keybindingsMenuRotation;
        public SwitchMenus loadMenu;

        public bool returnToMenu;

        public void ToOptions()
        {
            returnToMenu = true;
            loadMenu.HideOptions();
        }

        void Update()
        {
            if (returnToMenu)
            {
                Return();

                if (Vector3.Distance(transform.position, keybindingsMenuPosition.transform.position) < 0.1f)
                {
                    returnToMenu = false;
                    loadMenu.ToKeyBindings();
                    GetComponent<Transform>().position = keybindingsMenuPosition.transform.position;
                    transform.LookAt(keybindingsMenuRotation.transform);
                }
            }
        }

        void Return()
        {
            GetComponent<Transform>().position = Vector3.MoveTowards(transform.position, keybindingsMenuPosition.transform.position, (Time.deltaTime * 20f));
            GetComponent<Transform>().rotation = Quaternion.Slerp(transform.rotation, keybindingsMenuPosition.transform.rotation, (Time.deltaTime * 2f));
        }
    }
}