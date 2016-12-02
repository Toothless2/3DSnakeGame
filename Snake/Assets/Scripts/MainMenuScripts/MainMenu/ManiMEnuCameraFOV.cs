using UnityEngine;

namespace Snake
{
    public class ManiMEnuCameraFOV : MonoBehaviour
    {
        void Update()
        {
            if(Time.time > 0.05f)
            {
                Camera.main.fieldOfView = Constants.FOV;
            }
        }
    }
}