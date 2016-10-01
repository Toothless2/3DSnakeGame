using UnityEngine;
using System.Collections;

namespace Snake
{
    public class BodyScript : MonoBehaviour
    {
        /*
        * Moves a body pies toward the piece in frount of it
        */

        public int index;

        //this parts target(the body piece/head infront of it)
        public Transform target;

        private float moveSpeed;

        void Update()
        {
            MovePart();
        }

        void MovePart()
        {
            //if the part does have a target it should move
            if (target != null)
            {
                //look at the target
                transform.LookAt(target.position);

                //sets the movespeed of the piece
                moveSpeed = Time.deltaTime * (transform.parent.transform.GetComponent<PlayerSpeed>().speed + 0.2f);
                //clamps it
                moveSpeed = Mathf.Clamp(moveSpeed, 0.0f, 10.0f);

                //if the piece is to close to the one infrount stop
                if (Vector3.Distance(transform.position, target.position) < 2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.position, 0);
                }
                //else moe towards it
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
                }
            }
        }

        //chesk if the segment has collided with someting
        void OnTriggerEnter(Collider other)
        {
            //print(other.transform.name);
            //checks what is has collidered with
            //if it has collider with a segment it checks that it is not the one directly infront as they can sometimes touch
            if(other.transform.GetComponent<BodyScript>() != null)
            {
                BodyScript othersScript = other.transform.GetComponent<BodyScript>();

                if(othersScript.index > index)
                {
                    if(othersScript.index - 1 != index)
                    {
                        EventHandler.eventHandler.CallEndGameCollisionEvent(other.transform.position);
                    }
                }
            }
            //chesck it the segemtn has collided with the head and it is not the segment directly behind the head
            else if(other.transform.GetComponent<HeadScript>() != null)
            {
                if(index != 1)
                {
                    EventHandler.eventHandler.CallEndGameCollisionEvent(other.transform.position);
                }
            }
            //checks if the segment has collided with the tail and if it is not the segmet directly or 2 setpps behind the tail
            else if(other.transform.GetComponent<TailScript>() != null)
            {
                if((index != transform.parent.transform.GetComponent<PlayerSpeed>().index) && (index != transform.parent.transform.GetComponent<PlayerSpeed>().index - 1))
                {
                    EventHandler.eventHandler.CallEndGameCollisionEvent(other.transform.position);
                }
            }
        }
    }
}