using UnityEngine;
using System.Collections;

namespace Snake
{
    public class BackToOptions : MonoBehaviour
    {
        public GameObject optionsMenu;

        public void ToOptions()
        {
            gameObject.SetActive(false);
            optionsMenu.SetActive(true);
        }
    }
}