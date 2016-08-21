using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Snake
{
    public class HealthBar : MonoBehaviour
    {
        /*
        makes a health bar the takc down faster the more segments are on the snake
        */

        public Slider healthBar;

        int snakeLength = 0;
        public float stepIncrement;

        void Start()
        {
            SetEvents();
        }

        void SetEvents()
        {
            EventHandler.eventHandler.addSegmentEvent += IncreaseSnakeLength;
        }

        void Update()
        {
            CheckSnakeLength();
            CheckSliderValue();
        }

        void IncreaseSnakeLength()
        {
            snakeLength++;
            healthBar.value = healthBar.maxValue;
        }

        void CheckSnakeLength()
        {
            if(snakeLength > 0)
            {
                DecrementHelthSlider();
            }
        }

        void DecrementHelthSlider()
        {
            stepIncrement = (snakeLength / 50.0f) * Time.deltaTime;

            healthBar.value -= stepIncrement;
        }

        void CheckSliderValue()
        {
            if(healthBar.value == 0)
            {
                EventHandler.eventHandler.CallEndGameLowHealthEvent();
            }
        }
    }
}