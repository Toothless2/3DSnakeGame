using UnityEngine;
using System.Collections;

namespace Snake
{
    [RequireComponent(typeof (CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        /*
        * Moves the Player in the direction it is looking.
        * Speed can be changed eith by player input or in inspector
        */

        //move speed is clamped
        [Range(0.0f, 10.0f)]
        public float moveSpeed;

        private Vector3 moveDirection;

        private PlayerSpeed speed;

        void Start()
        {
            speed = transform.parent.transform.GetComponent<PlayerSpeed>();
        }

        void Update()
        {
            if (Time.timeScale > 0)
            {
                if (Input.GetAxis("SpeedAdjust") > 0)
                {
                    moveSpeed++;
                }

                if (Input.GetAxis("SpeedAdjust") < 0)
                {
                    moveSpeed--;
                }

                moveSpeed = Mathf.Clamp(moveSpeed, 0.1f, 10.0f);

                speed.speed = moveSpeed;

                //converts the move speed into a direction
                moveDirection = transform.forward * moveSpeed * Time.deltaTime;
                //applies the movement
                GetComponent<CharacterController>().Move(moveDirection);
            }
        }
    }
}