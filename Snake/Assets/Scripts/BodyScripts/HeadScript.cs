using UnityEngine;
using System.Collections.Generic;

namespace Snake
{
    public class HeadScript : MonoBehaviour
    {
        public List<GameObject> bodyPieces;

        public int index;

        public GameObject bodyPart;
        public GameObject tailPart;

        private GameObject currentTail;

        void Start()
        {
            SetEvents();
            FirstPart();
        }

        void SetEvents()
        {
            EventHandler.eventHandler.addSegmentEvent += AddPart;
            EventHandler.eventHandler.removeSegmentEvent += RemovePart;
        }

        void FirstPart()
        {
            bodyPieces.Add(gameObject);

            foreach (Transform child in transform.parent)
            {
                if (child.GetComponent<BodyScript>() != null)
                {
                    index++;
                    //sets the parts index
                    child.GetComponent<BodyScript>().index = index;
                    //adds the child to the list
                    bodyPieces.Add(child.gameObject);
                    //sets the target of the body part to the previous lone in the list
                    child.GetComponent<BodyScript>().target = bodyPieces[index - 1].transform;
                }
            }

            RemakeTail();
        }

        //called by the AddNewPart script
        public void AddPart()
        {
            GameObject newPart;

            /*
            * Will spawn a new part bihind the last object in the array
            * Then set the parent to the player containter
            * Then makes it the last sibling for neatness
            * then adds the new part to the list
            * Increments the segment index and sets the segment to the correct index
            * also sets the target of the segment to the segment a head of it
            */
            
            newPart = (GameObject)Instantiate(bodyPart, bodyPieces[index].transform.position + (bodyPieces[index].transform.forward * -1), Quaternion.identity);
            newPart.transform.SetParent(transform.parent.transform);
            newPart.transform.SetAsLastSibling();
            bodyPieces.Add(newPart);

            index++;
            newPart.GetComponent<BodyScript>().index = index;
            newPart.GetComponent<BodyScript>().target = bodyPieces[index - 1].transform;

            transform.parent.GetComponent<PlayerSpeed>().index = index;

            //when a new segment is added it remakes the tail
            RemakeTail();
        }

        //remove a segment
        void RemovePart()
        {
            //if the snake has nop segments to remove call the game over event
            if(index == 0)
            {
                EventHandler.eventHandler.CallEndGameLowHealthEvent();
            }
            else
            {
                //make a copt of the opject in the last position
                GameObject temp = bodyPieces[index];
                //remove it from the list
                bodyPieces.Remove(bodyPieces[index]);
                //destory it
                Destroy(temp);
                //decrement the number of segments
                index--;
                
                RemakeTail();
            }
        }

        void RemakeTail()
        {
            //if a tail has already been created destry it
            if(currentTail != null)
            {
                Destroy(currentTail);
            }

            //if the snake has no segments set the tail poz to the head
            if (index == 0)
            {
                currentTail = (GameObject)Instantiate(tailPart, bodyPieces[index].transform.position + (bodyPieces[index].transform.forward * -1), Quaternion.identity);
            }
            //else set its poition to the last segment
            else
            {
                currentTail = (GameObject)Instantiate(tailPart, bodyPieces[index].transform.position + (bodyPieces[index].transform.forward * -1), Quaternion.identity);
            }

            //set the parent
            currentTail.transform.SetParent(transform.parent.transform);

            //set as the last sibling for neatness
            currentTail.transform.SetAsLastSibling();

            currentTail.GetComponent<TailScript>().target = bodyPieces[index].transform;
        }
    }
}