using UnityEngine;
using System.Collections;

namespace Snake
{
    public class LoadOptionsMenu : MonoBehaviour
    {
        public GameObject optionsMenu;

        public void LoadOptMenu()
        {
            gameObject.SetActive(false);
            optionsMenu.SetActive(true);
        }
    }
}