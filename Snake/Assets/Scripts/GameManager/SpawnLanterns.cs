using UnityEngine;
using System.Collections;

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

        void Awake()
        {
            SetEvents();
        }

        void SetEvents()
        {
            EventHandler.eventHandler.startGameEvent += SpawnLantern;
            EventHandler.eventHandler.addSegmentEvent += LanternEaten;
            EventHandler.eventHandler.removeLanternEvent += LanternDespawn;
        }

        void LanternDespawn()
        {
            lanternCount--;
            ReplaceLantern();
        }

        void LanternEaten()
        {
            lanternCount--;
            SpawnLantern();
        }

        void ReplaceLantern()
        {
            if (lanternCount < maxLanterns)
            {
                Instantiate(lantern, RandomSpawnPozition(), Quaternion.identity);
                lanternCount++;
            }
        }

        void SpawnLantern()
        {
            if (lanternCount < maxLanterns)
            {
                int numberToSpawn = Random.Range(1, 4);

                for (int i = 0; i < numberToSpawn; i++)
                {
                    Instantiate(lantern, RandomSpawnPozition(), Quaternion.identity);
                    lanternCount++;
                }
            }
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