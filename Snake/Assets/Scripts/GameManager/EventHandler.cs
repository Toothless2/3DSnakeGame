using UnityEngine;
using System.Collections;

namespace Snake
{
    public class EventHandler : MonoBehaviour
    {
        public static EventHandler eventHandler;

        void Awake()
        {
            Time.timeScale = 1;
            eventHandler = this;
        }

        public delegate void GeneralEventHandler();
        public event GeneralEventHandler endGamelowHealthEvent;
        public event GeneralEventHandler endGameCollisionEvent;
        public event GeneralEventHandler addSegmentEvent;
        public event GeneralEventHandler removeSegmentEvent;
        public event GeneralEventHandler removeLanternEvent;

        public delegate void GameOverCollisionEventHandler(Vector3 position);
        public event GameOverCollisionEventHandler endGameCollisionPositionEvent;

        public void CallEndGameLowHealthEvent()
        {
            if(endGamelowHealthEvent != null)
            {
                endGamelowHealthEvent();
            }
        }

        public void CallEndGameCollisionEvent()
        {
            if(endGameCollisionEvent != null)
            {
                endGameCollisionEvent();
            }
        }

        public void CallEndGameCollisionEvent(Vector3 position)
        {
            if(endGameCollisionPositionEvent != null)
            {
                endGameCollisionPositionEvent(position);
            }
        }

        public void CallAddSegmentEvent()
        {
            if(addSegmentEvent != null)
            {
                addSegmentEvent();
            }
        }

        public void CallRemoveSegmentEvent()
        {
            if(removeSegmentEvent != null)
            {
                removeSegmentEvent();
            }
        }

        public void CallRemoveLanternEvent()
        {
            if (removeLanternEvent != null)
            {
                removeLanternEvent();
            }
        }
    }
}