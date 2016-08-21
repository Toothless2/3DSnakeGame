using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class SpawnLanterns : MonoBehaviour
    {

        /*
        Will spawn lanterns at random points bewteen 2 given co-ordinates
        */

        public GameObject lantern;

        public int maxLanterns;
        private int lanternCount;

        public Transform[] spawnLimits;

        private float waitTime;

        void Start()
        {
            SetEvents();
        }

        void SetEvents()
        {
            EventHandler.eventHandler.addSegmentEvent += RemoveLantern;
        }

        void Update()
        {
            if (lanternCount < maxLanterns)
            {
                if(Time.time > waitTime)
                {
                    SpawnLantern();
                }
            }
        }

        void RemoveLantern()
        {
            lanternCount--;
        }

        void SpawnLantern()
        {
            waitTime = Time.time + Random.Range(0.1f, 5.0f);

            Instantiate(lantern, RandomSpawnPozition(), Quaternion.identity);
            lanternCount++;
        }

        //ramdomizes each of the axis values
        Vector3 RandomSpawnPozition()
        {
            float x = Random.Range(spawnLimits[0].position.x, spawnLimits[1].position.x);
            float y = Random.Range(spawnLimits[0].position.y, spawnLimits[1].position.y);
            float z = Random.Range(spawnLimits[0].position.z, spawnLimits[1].position.z);

            return new Vector3(x, y, z);
        }
    }
}