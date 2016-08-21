using UnityEngine;
using System.Collections;

namespace Snake
{
    public class EventHandler : MonoBehaviour
    {
        public static EventHandler eventHandler;

        void Awake()
        {
            eventHandler = this;
        }

        public delegate void GeneralEventHandler();
        public event GeneralEventHandler endGamelowHealthEvent;
        public event GeneralEventHandler endGameCollisionEvent;
        public event GeneralEventHandler addSegmentEvent;
        public event GeneralEventHandler removeSegmentEvent;

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
    }
}