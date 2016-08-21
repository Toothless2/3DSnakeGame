using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Snake
{
    public class LengthCounter : MonoBehaviour
    {
        public Text counter;
        int number = 1;

        void Start()
        {
            SetEvents();
            counter.enabled = false;
        }

        void SetEvents()
        {
            EventHandler.eventHandler.addSegmentEvent += AddToCounter;
            EventHandler.eventHandler.removeSegmentEvent += RemoveFromCounter;
            EventHandler.eventHandler.endGameCollisionEvent += HideOnGameOver;
            EventHandler.eventHandler.endGamelowHealthEvent += HideOnGameOver;
        }

        //adds one to the length counter
        void AddToCounter()
        {
            if(!(counter.enabled))
            {
                counter.enabled = true;
            }

            counter.text = "Length: " + number;
            number++;
        }

        //removes from the length counter
        void RemoveFromCounter()
        {
            if(counter.enabled)
            {
                number--;
                counter.text = "Length: " + number;
            }
        }

        //hides the overloay on game over
        void HideOnGameOver()
        {
            number = 1;
            counter.gameObject.SetActive(false);
        }
    }
}