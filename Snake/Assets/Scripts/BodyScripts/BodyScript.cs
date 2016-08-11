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
                if (Vector3.Distance(transform.position, target.position) < 1.2)
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

        void CheckCollision()
        {

        }
    }
}