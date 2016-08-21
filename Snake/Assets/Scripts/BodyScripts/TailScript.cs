using UnityEngine;
using System.Collections;

namespace Snake
{
    public class TailScript : MonoBehaviour
    {
        public Transform target;
        private PlayerSpeed container;
        private float moveSpeed;

        void Start()
        {
            //make a local copy of this for optimisation
            container = transform.parent.GetComponent<PlayerSpeed>();
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
            else //else move towards the target
            {
                transform.LookAt(target);

                moveSpeed = Time.deltaTime * (container.speed + 0.2f);

                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
            }
        }
    }
}