using UnityEngine;
using System.Collections;

namespace Snake
{
    public class DespawnAfterTime : MonoBehaviour
    {
        public Light lanternLight;
        float timeUntilDespawn;

        void Start()
        {
            timeUntilDespawn = Random.Range(5.0f, 15.0f);
        }

        void FixedUpdate()
        {
            if (lanternLight.intensity <= 0)
            {
                Destroy(gameObject);
                EventHandler.eventHandler.CallRemoveLanternEvent();
            }
            else
            {
                lanternLight.intensity -= (timeUntilDespawn / 100) * Time.deltaTime;
            }
        }
    }
}