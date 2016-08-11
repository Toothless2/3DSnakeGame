using UnityEngine;
using System.Collections;
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
            bodyPieces.Add(gameObject);

            foreach(Transform child in transform.parent)
            {
                if(child.GetComponent<BodyScript>() != null)
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

            //spawns the new part at the position of the last thing in the array
            newPart = (GameObject)Instantiate(bodyPart, bodyPieces[index].transform.position, Quaternion.Euler(Vector3.zero));
            //sets the parent to the correct thing
            newPart.transform.SetParent(transform.parent.transform);
            //makes the new part the last sibling for neatness
            newPart.transform.SetAsLastSibling();
            //adds the new part to the list
            bodyPieces.Add(newPart);

            //increments the index by 1 so it is correct
            index++;
            //sets the index so the body segment
            newPart.GetComponent<BodyScript>().index = index;
            //sets the target to the last thing in the list
            newPart.GetComponent<BodyScript>().target = bodyPieces[index - 1].transform;

            transform.parent.GetComponent<PlayerSpeed>().index = index;

            //when a new segment is added it remakes the tail
            RemakeTail();
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
                currentTail = (GameObject)Instantiate(tailPart, transform.position, Quaternion.Euler(Vector3.zero));
            }
            //else set its poition to the last segment
            else
            {
                currentTail = (GameObject)Instantiate(tailPart, bodyPieces[index - 1].transform.position, Quaternion.Euler(Vector3.zero));
            }

            //set the parent
            currentTail.transform.SetParent(transform.parent.transform);

            //set as the last sibling for neatness
            currentTail.transform.SetAsLastSibling();
        }
    }
}