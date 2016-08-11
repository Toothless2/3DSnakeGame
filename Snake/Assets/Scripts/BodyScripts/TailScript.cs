using UnityEngine;
using System.Collections;

namespace Snake
{
    public class TailScript : MonoBehaviour
    {
        private Transform target;
        private PlayerSpeed container;
        private float moveSpeed;

        void Start()
        {
            //make a local copy of this for optimisation
            container = transform.parent.GetComponent<PlayerSpeed>();

            //when the tail is spawned position it correctly
            PositionTail();
        }

        void Update()
        {
            //every  update the tail should move
            UpdateTailPosition();
        }

        //moves the tail
        void UpdateTailPosition()
        {
            //if the distance is between this object and the target is less then 1.2 units it shouldnt move
            if (Vector3.Distance(transform.position, target.position) < 1.2)
            {
                transform.LookAt(target);
            }
            else//ele move towards the target
            {
                transform.LookAt(target);

                moveSpeed = Time.deltaTime * (container.speed + 0.2f);

                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
            }
        }

        void PositionTail()
        {
            //if the snake has no segments the tail shout floow the head
            if (container.index == 0)
            {
                target = transform.parent.FindChild("Head").GetComponent<Transform>();

                transform.position = target.position;
            }
            //otherwise it floows the last segement in the list
            else
            {
                target = transform.parent.FindChild("Head").GetComponent<HeadScript>().bodyPieces[container.index].transform;

                transform.position = target.position;
            }
        }
    }
}