using UnityEngine;
using System.Collections;

namespace Snake
{
    public class MoveCameraToCollision : MonoBehaviour
    {
        public GameObject playerCamera;

        void Start()
        {
            SetEvents();
        }

        void SetEvents()
        {
            EventHandler.eventHandler.endGameCollisionPositionEvent += MoveCameraToPosition;
        }

        //moves the players camera to the posiition of the collision and ends the game
        void MoveCameraToPosition(Vector3 position)
        {
            playerCamera.transform.position = position;
            playerCamera.transform.LookAt(position);
            playerCamera.transform.position -= playerCamera.transform.forward;
            playerCamera.transform.position -= playerCamera.transform.right;
            playerCamera.transform.LookAt(position);

            EventHandler.eventHandler.CallEndGameCollisionEvent();
        }
    }
}