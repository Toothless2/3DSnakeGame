using UnityEngine;
using System.Collections;

namespace Snake
{
    public class AddNewPart : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            //if the head of the player collides with the spawner add a new segment and destry the segment spawner
            if (other.gameObject.GetComponent<HeadScript>() != null)
            {
                EventHandler.eventHandler.CallAddSegmentEvent();

                Destroy(transform.parent.gameObject);
            }
        }
    }
}