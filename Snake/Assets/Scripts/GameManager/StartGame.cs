using UnityEngine;
using System.Collections;

namespace Snake
{
    public class StartGame : MonoBehaviour
    {
        void Start()
        {
            EventHandler.eventHandler.CallStartGameEvent();
        }
    }
}