using UnityEngine;
using System.Collections;

namespace Snake
{
    public class TailScript : MonoBehaviour
    {
        public Transform target;
        public PlayerSpeed container;
        public float moveSpeed;

        void Start()
        {
            container = transform.parent.GetComponent<PlayerSpeed>();

            if (container.index == 0)
            {
                target = transform.parent.FindChild("Head").GetComponent<Transform>();

                transform.position = target.position;
            }
            else
            {
                target = transform.parent.FindChild("Head").GetComponent<HeadScript>().bodyPieces[container.index].transform;

                transform.position = target.position;
            }
        }

        void Update()
        {
            if(Vector3.Distance(transform.position, target.position) < 1.2)
            {
                transform.LookAt(target);
            }
            else
            {
                transform.LookAt(target);

                moveSpeed = Time.deltaTime * (container.speed + 0.2f);

                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
            }
        }
    }
}