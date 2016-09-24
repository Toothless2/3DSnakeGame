using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Snake
{
    public class LengthCounter : MonoBehaviour
    {
        public Text counter;
        public int number = 0;

        void Awake()
        {
            SetEvents();
        }

        void SetEvents()
        {
            EventHandler.eventHandler.startGameEvent += AddToCounter;
            EventHandler.eventHandler.addSegmentEvent += AddToCounter;
            EventHandler.eventHandler.removeSegmentEvent += RemoveFromCounter;
        }

        //adds one to the length counter
        void AddToCounter()
        {
            counter.text = "Score: " + number;
            number++;
        }

        //removes from the length counter
        void RemoveFromCounter()
        {
            if(counter.enabled)
            {
                number--;
                counter.text = "Score: " + number;
            }
        }
    }
}